using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MvvmSampleAgainViewModel
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// オブジェクトに検証エラーがあるかどうかを示す値を取得します
        /// </summary>
        public bool HasErrors
        {
            get
            {
                //バリデーションエラー中のプロパティがあるかを返す
                IEnumerable<string> errMsgs = this.Validate();
                return errMsgs.Count() > 0;
            }
        }

        /// <summary>
        /// 指定されたプロパティの検証エラーを取得します
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEnumerable GetErrors(string propertyName)
        {
            //プロパティを検証
            PropertyInfo info = this.GetType().GetProperty(propertyName);
            List<string> errMsgs = this.ValidateProperty(info);
            if (errMsgs.Count == 0)
            {
                //エラー無しの場合は、Nullを返す
                return null;
            }
            else
            {
                //エラーメッセージを返す
                return errMsgs;
            }
        }

        /// <summary>
        /// ViewModelをバリデートする
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Validate()
        {
            IEnumerable<string> result = new List<string>();

            //ValidationAttributeが付与されているプロパティの情報を収集する
            IEnumerable<PropertyInfo> propertyInfos = this.GetType()
                                                    .GetProperties()
                                                    .Where(propertyInfo =>
                                                    this.HasValidationAttribute(propertyInfo));

            foreach (var propertyInfo in propertyInfos)
            {
                //エラーの場合、戻り値にマージ
                List<string> msgs = this.ValidateProperty(propertyInfo);
                result = result.Union(msgs);
            }

            return result;
        }

        /// <summary>
        /// PropertyChangedイベントを発行する
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged(string propertyName)
        {
            if(this.ErrorsChanged != null)
            {
                var e = new DataErrorsChangedEventArgs(propertyName);
                this.ErrorsChanged(this, e);
            }
        }

        /// <summary>
        ///ErrorsChangedイベントを発行する 
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaiseErrorChanged(string propertyName)
        {
            if (this.ErrorsChanged != null)
            {
                var e = new DataErrorsChangedEventArgs(propertyName);
                this.ErrorsChanged(this, e);
            }
        }

        /// <summary>
        /// ValidationAttributeが付与されているかを判定する
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        private bool HasValidationAttribute(PropertyInfo pi)
        {
            return pi.CanRead
                && pi.GetCustomAttributes(typeof(ValidationAttribute), false).Length > 0;
        }

        /// <summary>
        /// プロパティをバリデートする
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private List<string>ValidateProperty(PropertyInfo info)
        {
            string propertyName = info.Name;
            object propertyValue = info.GetValue(this, null);

            var context = new ValidationContext(this, null, null);
            context.MemberName = propertyName;

            var results = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(propertyValue, context, results))
            {
                //文字列のリストに変換して返す
                return results.Select(vr => vr.ErrorMessage)
                                .ToList();
            }
            else
            {
                //エラーがない場合、空リストを返す
                return new List<string>();
            }
        }

    }
}

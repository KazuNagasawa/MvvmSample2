using Microsoft.Practices.Prism.Commands;
using MvvmSampleAgainModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace MvvmSampleAgainViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private InteractionRequest<Confirmation> alertRequest;
        private DelegateCommand addRecordCommand;
        private string heightTextBox_Text = string.Empty;
        private string weightTextBox_Text = string.Empty;
        private MainModel model = new MainModel();

        public MainViewModel()
        {
            this.alertRequest = new InteractionRequest<Confirmation>();
            this.addRecordCommand = new DelegateCommand(this.AddRecord);
        }

        public IInteractionRequest AlertRequest
        {
            get { return this.alertRequest; }
        }

        /// <summary>
        /// 計算ボタンのクリックイベントに対応するコマンド
        /// </summary>
        public DelegateCommand AddRecordCommand
        {
            get { return this.addRecordCommand; }
        }


        [RegularExpression(
            @"^[0-9]+(\.)?[0-9]*$",
            ErrorMessage ="身長には正の数値を入力してください。")]
        [Required(ErrorMessage = "身長を入力してください")]
        public string HeightTextBox_Text
        {
            get
            {
                return this.heightTextBox_Text;
            }
            set
            {
                if (!Equals(this.heightTextBox_Text, value))
                {
                    this.heightTextBox_Text = value;
                    this.RaisePropertyChanged("HeightTextBox_Text");
                    this.RaiseErrorChanged("HeightTextBox_Text");
                }
            }
        }

        [RegularExpression(
            @"^[0-9]+(\.)?[0-9]*$",
            ErrorMessage ="体重には正の数値を入力してください。")]
        [Required(ErrorMessage ="体重を入力してください")]
        public string WeightTextBox_Text
        {
            get
            {
                return this.weightTextBox_Text;
            }
            set
            {
                if (!Equals(this.weightTextBox_Text, value))
                {
                    this.weightTextBox_Text = value;
                    this.RaisePropertyChanged("WeightTextBox_Text");
                    this.RaiseErrorChanged("WeightTextBox_Text");
                }
            }
        }

        public ObservableCollection<BMIRecord> Records
        {
            get { return this.model.Records; }
        }


        /// <summary>
        /// BMIRecordを履歴に追加する
        /// </summary>
        public void AddRecord()
        {
            //値が入力されているかチェックする
            var errMessages = this.Validate();
            if (errMessages.Count() == 0)
            {
                //BMIを履歴に追加する
                double cmHeight = double.Parse(this.HeightTextBox_Text);
                double weight = double.Parse(this.WeightTextBox_Text);
                this.model.AddRecord(cmHeight, weight);
            }
            else
            {
                //Viewにエラーメッセージダイアログ表示リクエストを投げる
                var confirmation = new Confirmation();
                confirmation.Title = "バリデーションエラー";
                confirmation.Content = string.Join(Environment.NewLine, errMessages);
                alertRequest.Raise(confirmation);
            }
        }
    }
}

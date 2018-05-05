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
using System.Collections.ObjectModel;

namespace MvvmSampleAgainModel
{
    public class MainModel
    {
        private int id = 0;

        public MainModel()
        {
            this.Records = new ObservableCollection<BMIRecord>();
        }

        /// <summary>
        /// BMI計算結果の履歴を取得する
        /// </summary>
        public ObservableCollection<BMIRecord> Records { get; private set; }

        /// <summary>
        /// BMIRecordをItemSouceに追加する
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        public void AddRecord(double height,double weight)
        {
            var record = this.CreateRecord(height, weight);
            this.Records.Add(record);
        }

        /// <summary>
        /// BMIRecordクラスを生成する
        /// </summary>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        private BMIRecord CreateRecord(double height,double weight)
        {
            //BMIを計算
            double mHeight = height / 100;
            double bmi = weight / (mHeight * mHeight);

            //BMIRecordクラスを生成
            var record = new BMIRecord()
            {
                ID = this.id++,
                DateTime = DateTime.Now,
                Height = height,
                Weight = weight,
                BMI = bmi
            };

            return record;
        }


    }
}

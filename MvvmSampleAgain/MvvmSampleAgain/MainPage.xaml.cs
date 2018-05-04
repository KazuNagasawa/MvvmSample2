using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace MvvmSampleAgain
{
    public partial class MainPage : UserControl
    {
        private ObservableCollection<BMIRecord> bmiRecords = new ObservableCollection<BMIRecord>();
        private int id = 0;

        public MainPage()
        {
            InitializeComponent();

            this.RecordListBox.ItemsSource = this.bmiRecords;

            this.CalcButton.Click += this.CalcButton_Click;
        }

        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            // 身長を取得
            double cmHeight;
            if (!double.TryParse(this.HeightTextBox.Text, out cmHeight))
            {
                // 数値以外が入力されていた場合、メッセージを表示して何もしない。
                MessageBox.Show("身長には数値を入力してください。");
                return;
            }
            else if (cmHeight <= 0)
            {
                // ０または負の値が入力されていた場合、メッセージを表示して何もしない。
                MessageBox.Show("身長には正の数を入力してください。");
                return;
            }

            // 体重を取得
            double weight;
            if (!double.TryParse(this.WeightTextBox.Text, out weight))
            {
                // 数値以外が入力されていた場合、メッセージを表示して何もしない。
                MessageBox.Show("体重には数値を入力してください。");
                return;
            }
            else if (weight <= 0)
            {
                // ０または負の値が入力されていた場合、メッセージを表示して何もしない。
                MessageBox.Show("体重には正の数を入力してください。");
                return;
            }

            // BMIを計算
            double mHeight = cmHeight / 100;
            double bmi = weight / (mHeight * mHeight);

            // BMIRecordクラスを生成
            var record = new BMIRecord();
            record.ID = this.id++;
            record.DateTime = DateTime.Now;
            record.Height = cmHeight;
            record.Weight = weight;
            record.BMI = bmi;

            // データグリッドに追加
            this.bmiRecords.Add(record);
        }
    }
}

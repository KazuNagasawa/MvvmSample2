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
using MvvmSampleAgainModel;

namespace MvvmSampleAgain
{
    public partial class MainPage : UserControl
    {
        //モデルを保持する
        private MainModel model = new MainModel();


        public MainPage()
        {
            InitializeComponent();

            //モデルのRecordsプロパティをリストボックスにセットする
            this.RecordListBox.ItemsSource = this.model.Records;

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

            this.model.AddRecord(cmHeight, weight);
        }
    }
}

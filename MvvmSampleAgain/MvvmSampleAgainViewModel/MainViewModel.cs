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
using System.ComponentModel.DataAnnotations;

namespace MvvmSampleAgainViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private string heightTextBox_Text = string.Empty;
        private string weightTextBox_Text = string.Empty;

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
    }
}

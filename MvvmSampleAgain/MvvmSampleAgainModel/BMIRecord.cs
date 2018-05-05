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

namespace MvvmSampleAgainModel
{
    public class BMIRecord
    {
        /// <summary>
        /// ユニークなID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 記録した日時
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 体重(kg)
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// 身長(cm)
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// BMI値
        /// </summary>
        public double BMI { get; set; }

    }
}

﻿#pragma checksum "C:\Users\Nagasawa\Documents\MvvmSample2\MvvmSampleAgain\MvvmSampleAgain\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1C3999D4C9D48BB656EA1E6320F116F7"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MvvmSampleAgain {
    
    
    public partial class MainPage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox HeightTextBox;
        
        internal System.Windows.Controls.TextBox WeightTextBox;
        
        internal System.Windows.Controls.Button CalcButton;
        
        internal System.Windows.Controls.ListBox RecordListBox;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MvvmSampleAgain;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.HeightTextBox = ((System.Windows.Controls.TextBox)(this.FindName("HeightTextBox")));
            this.WeightTextBox = ((System.Windows.Controls.TextBox)(this.FindName("WeightTextBox")));
            this.CalcButton = ((System.Windows.Controls.Button)(this.FindName("CalcButton")));
            this.RecordListBox = ((System.Windows.Controls.ListBox)(this.FindName("RecordListBox")));
        }
    }
}


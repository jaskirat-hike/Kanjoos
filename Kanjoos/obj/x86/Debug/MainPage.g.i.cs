﻿#pragma checksum "E:\WP8 Apps\Kanjoos\Kanjoos\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3914EADDE956D8C8BA20E1CE72D110D8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
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


namespace Kanjoos {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock tb_balance;
        
        internal System.Windows.Controls.TextBlock tb_expenditure;
        
        internal System.Windows.Controls.Button btn_add_trans;
        
        internal Microsoft.Phone.Controls.LongListSelector lls_top_expenses;
        
        internal Microsoft.Phone.Controls.LongListSelector lls_expenses;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Kanjoos;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.tb_balance = ((System.Windows.Controls.TextBlock)(this.FindName("tb_balance")));
            this.tb_expenditure = ((System.Windows.Controls.TextBlock)(this.FindName("tb_expenditure")));
            this.btn_add_trans = ((System.Windows.Controls.Button)(this.FindName("btn_add_trans")));
            this.lls_top_expenses = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("lls_top_expenses")));
            this.lls_expenses = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("lls_expenses")));
        }
    }
}


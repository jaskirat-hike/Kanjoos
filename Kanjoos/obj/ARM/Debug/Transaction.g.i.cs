﻿#pragma checksum "E:\WP8 Apps\Kanjoos\Kanjoos\Transaction.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BD646F5E361B24F78A2365817EAAE234"
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
    
    
    public partial class Transaction : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox expense_amount;
        
        internal System.Windows.Controls.TextBox expense_category;
        
        internal System.Windows.Controls.TextBox expense_detail;
        
        internal System.Windows.Controls.Button add_expense;
        
        internal System.Windows.Controls.TextBox income_amount;
        
        internal System.Windows.Controls.Button add_income;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Kanjoos;component/Transaction.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.expense_amount = ((System.Windows.Controls.TextBox)(this.FindName("expense_amount")));
            this.expense_category = ((System.Windows.Controls.TextBox)(this.FindName("expense_category")));
            this.expense_detail = ((System.Windows.Controls.TextBox)(this.FindName("expense_detail")));
            this.add_expense = ((System.Windows.Controls.Button)(this.FindName("add_expense")));
            this.income_amount = ((System.Windows.Controls.TextBox)(this.FindName("income_amount")));
            this.add_income = ((System.Windows.Controls.Button)(this.FindName("add_income")));
        }
    }
}


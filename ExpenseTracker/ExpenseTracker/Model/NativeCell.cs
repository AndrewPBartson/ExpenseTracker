using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ExpenseTracker.Model
{
    public class NativeCell : ViewCell
    {
        public static readonly BindableProperty NameProperty =
          BindableProperty.Create("Name", typeof(string), typeof(NativeCell), "");

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly BindableProperty ExpenseAmountProperty =
          BindableProperty.Create("ExpenseAmount", typeof(string), typeof(NativeCell), "");

        public string ExpenseAmount
        {
            get { return (string)GetValue(ExpenseAmountProperty); }
            set { SetValue(ExpenseAmountProperty, value); }
        }


    }
}

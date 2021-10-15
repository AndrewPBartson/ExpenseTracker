using ExpenseTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetPage : ContentPage
    {
        public BudgetPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // if there is a value for budget from reading a file
            //   - Populate budget amount into field
            //   - Show "Edit" button
            //   - Show "Continue" button
            //   - After user clicks "Edit", "Continue" button 
            //     should be renamed "Save"

            // if there is NOT a value for budget
            //   - Disable "Edit" button
            //   - Disable "Save" button until user enters some amount
        }

        private void OnEditButtonClicked(object sender, EventArgs e)
        {
        //    //var expense = (Expense)BindingContext;
        //    //if (File.Exists(note.FileName))
        //    //{
        //    //    File.Delete(note.FileName);
        //    //}
        //    //editor.Text = string.Empty;
        //    //await Navigation.PushModalAsync(new AddExpensePage
        //    //{
        //    //    //BindingContext = (Expense)e.SelectedItem
        //    //});
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new ExpensePage
            //{
            //    BindingContext = (Expense)e.SelectedItem
            //});
        }

        private void OnViewExpensesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpensesPage
            {
                BindingContext = (Expense)e.SelectedItem
            });
        }
    }
}
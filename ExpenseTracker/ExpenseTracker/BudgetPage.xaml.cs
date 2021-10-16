using ExpenseTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
            User currentUser = UserManager.GetLoggedInUser();
            // if user has a Budget
            if (currentUser.Budgets.Count != 0)     
            {
                BudgetInput.Text = currentUser.Budgets[0].BudgetGoalAmount.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
            //   - Format budget amount in local currency
            //   - Show "Edit" button
            //   - Show "Continue" button
            //   - After user clicks "Edit", "Continue" button 
            //     should be renamed "Save"

            // if there is NOT a value for budget
            //   - Disable "Edit" button
            //   - Disable "Save" button until user enters some amount

        }


        private async void OnEditButtonClicked(object sender, EventArgs e) 
        { 
            await Navigation.PushModalAsync(new AddExpensePage());
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Budget currentBudget = new Budget();
            currentBudget.BudgetGoalAmount = decimal.Parse(BudgetInput.Text);
            currentBudget.BudgetDate = DateTime.Now;
            currentBudget.ListOfExpenses = new List<Expenses>();

            User currentUser = new User();
            currentUser = UserManager.GetLoggedInUser();
            currentUser.Budgets.Add(currentBudget);

            UserManager.SaveLoggedInUserData();
            await Navigation.PushModalAsync(new AddExpensePage());

        }

        private async void OnViewExpensesButtonClicked(object sender, EventArgs e)
        {
         
            await Navigation.PushModalAsync(new ExpensesPage { BindingContext = new Expenses() });
           
            return;
        }
    }
}
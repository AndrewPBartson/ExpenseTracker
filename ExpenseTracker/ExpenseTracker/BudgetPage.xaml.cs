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

        public Budget currentBudget;
        private DateTime budgetMonth;
        
        protected override void OnAppearing()
        {
            User currentUser = UserManager.GetLoggedInUser();
            if (currentUser.Budgets.Count != 0)     
            {
                // find index of current budget
                // load current budget data
                // allow user to edit BudgetGoalAmount
                BudgetInput.Text = currentUser.Budgets[0].BudgetGoalAmount.ToString(System.Globalization.CultureInfo.InvariantCulture);
                BudgetStatusReport.Text = $"Spent ${BudgetInput.Text} of ${BudgetInput.Text}";
                // allow user to select a different budge to edit (not this month's budget) -
                // add "Select Budget" button?
            }
            else // if user doesn't have any Budget objects
            {
                currentBudget = new Budget();
                budgetMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
        }

        private async void OnEditButtonClicked(object sender, EventArgs e) 
        { 
            await Navigation.PushModalAsync(new ExpensesPage());
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            currentBudget.BudgetGoalAmount = decimal.Parse(BudgetInput.Text);
            currentBudget.BudgetMonth = budgetMonth;

            User currentUser = new User();
            currentUser = UserManager.GetLoggedInUser();
            currentUser.Budgets.Add(currentBudget);
            UserManager.SaveLoggedInUserData();
            await Navigation.PushModalAsync(new ExpensesPage());
        }

        private async void OnViewExpensesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpensesPage { BindingContext = new Expenses() });  
            return;
        }
        public void OnMonthChosen(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                budgetMonth = new DateTime(budgetMonth.Year, selectedIndex + 1, 1);
            }
        }
        public void OnYearChosen(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                budgetMonth = new DateTime(selectedIndex + 2021, budgetMonth.Month, 1);
            };
        }

        public void SelectBudgetForUpdate(object sender, EventArgs e)
        {

        }
    }
}
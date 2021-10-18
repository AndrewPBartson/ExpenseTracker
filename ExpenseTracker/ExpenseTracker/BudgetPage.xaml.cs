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

        private string budgetMonth;
        private string budgetYear;

        protected override void OnAppearing()
        {
            User currentUser = UserManager.GetLoggedInUser();
            if (currentUser.Budgets.Count != 0)     
            {
                BudgetInput.Text = currentUser.Budgets[0].BudgetGoalAmount.ToString(System.Globalization.CultureInfo.InvariantCulture);
                BudgetStatusReport.Text = $"You have spent \n$ {BudgetInput.Text} from your monthly goal of \n$ {BudgetInput.Text}";
                //   - Show "Edit" button
                //   - Show "Continue" button
                //   - After user clicks "Edit", rename "Continue" to "Save"
            }
            else // if there is NOT a value for budget
            {
                //   - Disable "Edit" button
                //   - Disable "Save" button until user enters some amount
            }
        }

        private async void OnEditButtonClicked(object sender, EventArgs e) 
        { 
            await Navigation.PushModalAsync(new AddExpensePage());
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            currentBudget = new Budget();
            currentBudget.BudgetGoalAmount = decimal.Parse(BudgetInput.Text);
            currentBudget.BudgetDate = DateTime.Now;
            currentBudget.ListOfExpenses = new List<Expenses>();
            currentBudget.BudgetMonth = budgetMonth;
            currentBudget.BudgetYear = budgetYear;

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
        public void OnMonthChosen(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                budgetMonth = (string)picker.ItemsSource[selectedIndex];
            }
        }
        public void OnYearChosen(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                budgetYear = (string)picker.ItemsSource[selectedIndex];
            }
        }
    }
}
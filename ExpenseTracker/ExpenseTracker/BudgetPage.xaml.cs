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

        private DateTime budgetDate = DateTime.Now;
        private User currentUser = UserManager.GetLoggedInUser();

        protected override void OnAppearing()
        {
            Budget currentBudget = getMatchingBudget(budgetDate);

            // populate data into Pickers and BudgetInput
            BudgetInput.Text = currentBudget.BudgetGoalAmount.ToString(System.Globalization.CultureInfo.InvariantCulture);
            BudgetStatusReport.Text = $"Spent ${0} of ${currentBudget.BudgetGoalAmount}";

            int monthId = budgetDate.Month;
            int yearId = budgetDate.Year;
            BudgetMonthPicker.SelectedIndex = monthId - 1;
            BudgetYearPicker.SelectedIndex = yearId - 2021;
            getSummaryData();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Budget nextBudget = getMatchingBudget(budgetDate);

            nextBudget.BudgetGoalAmount = decimal.Parse(BudgetInput.Text);
            nextBudget.BudgetDate = budgetDate;
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
                budgetDate = new DateTime(budgetDate.Year, selectedIndex + 1, 1);
            }
            
            getSummaryData();
        }
        public void OnYearChosen(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                budgetDate = new DateTime(selectedIndex + 2021, budgetDate.Month, 1);
            }
            
            getSummaryData();
        }
        private Budget getMatchingBudget(DateTime date)
        {
            bool isBudgetAvailable = false;
            Budget targetBudget = new Budget();

            foreach (Budget budget in currentUser.Budgets)
            {
                if (budget.BudgetDate.Month == date.Month)
                {
                    isBudgetAvailable = true;
                    targetBudget = budget;
                    break;
                }
            }
            if (isBudgetAvailable == false)
            {
                targetBudget.BudgetGoalAmount = 0;
                targetBudget.BudgetDate = date;
                currentUser.Budgets.Add(targetBudget);
            }
            return targetBudget;
        }

        public void getSummaryData()
        {
            decimal totalHomeExpense = 0;
            decimal totalShoppingExpense = 0;
            decimal totalTravelExpense = 0;
            decimal totalFoodExpense = 0;
            decimal totalEntertainmentExpense = 0;
            decimal totalEducationExpense = 0;
            decimal totalBillsExpense = 0;
            decimal totalGiftExpense = 0;
            
            
            Budget currentBudget = Budget.getMatchingBudget(budgetDate, currentUser);
                        
            foreach (Expenses expense in currentBudget.ListOfExpenses)
            {
                if (expense.ExpenseCategory == Category.Home)
                {
                    totalHomeExpense = totalHomeExpense + expense.ExpenseAmount;
                }

                if (expense.ExpenseCategory == Category.Shopping)
                {
                    totalShoppingExpense = totalShoppingExpense + expense.ExpenseAmount;
                }
                
                if (expense.ExpenseCategory == Category.Travel)
                {
                    totalTravelExpense = totalTravelExpense + expense.ExpenseAmount;
                }
                
                if (expense.ExpenseCategory == Category.Food)
                {
                    totalFoodExpense = totalFoodExpense + expense.ExpenseAmount;
                }
                
                if (expense.ExpenseCategory == Category.Entertainment)
                {
                    totalEntertainmentExpense = totalEntertainmentExpense + expense.ExpenseAmount;
                }
                
                if (expense.ExpenseCategory == Category.Education)
                {
                    totalEducationExpense = totalEducationExpense + expense.ExpenseAmount;
                }
                
                if (expense.ExpenseCategory == Category.Bills)
                {
                    totalBillsExpense = totalBillsExpense + expense.ExpenseAmount;
                }
                
                if (expense.ExpenseCategory == Category.Gift)
                {
                    totalGiftExpense = totalGiftExpense + expense.ExpenseAmount;
                }
            }
            HomeTotal.Text = "$"+ totalHomeExpense.ToString();
            ShoppingTotal.Text = "$"+ totalShoppingExpense.ToString();
            TravelTotal.Text = "$"+ totalTravelExpense.ToString();
            FoodTotal.Text = "$"+ totalFoodExpense.ToString();
            EntertainmentTotal.Text = "$"+ totalEntertainmentExpense.ToString();
            EducationTotal.Text = "$"+ totalEducationExpense.ToString();
            BillsTotal.Text = "$"+ totalBillsExpense.ToString();
            GiftTotal.Text = "$"+ totalGiftExpense.ToString();
        }
    }
}
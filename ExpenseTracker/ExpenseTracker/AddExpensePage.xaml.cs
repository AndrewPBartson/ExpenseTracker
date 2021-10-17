using ExpenseTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.Json;


namespace ExpenseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpensePage : ContentPage
    {
        public AddExpensePage()
        {
            InitializeComponent();
        }

        private User currentUser = UserManager.GetLoggedInUser();
        public string name;
        public decimal amount;
        public DateTime date;
        public Category category;

        //Initializing on expense object -- Need to delete when integration is completed!
       // Expenses expense = new Expenses("Cycle", 256, DateTime.Now.AddDays(-7), Category.Shopping);
        


        protected override void OnAppearing()
        {
            var expense = (Expenses)BindingContext;
            if (!string.IsNullOrEmpty(expense.Description))
            {
                ExpenseLabel.Text = "Update Expense";
                ExpenseName.Text = expense.Description;
                ExpenseAmount.Text = expense.ExpenseAmount.ToString();
                ExpenseDate.Date = expense.ExpenseDate;
                ExpenseCategory.Text = $"Category: {expense.ExpenseCategory.ToString()}";
                SetCategoryIcon(expense.ExpenseCategory);
                AddSaveButton.Text = "Update";
                DeleteButton.IsVisible = true;
            }
        }

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            name = ExpenseName.Text;
            amount = Convert.ToDecimal(ExpenseAmount.Text);

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(ExpenseAmount.Text) && !string.IsNullOrWhiteSpace(category.ToString()))
            {
                foreach (Budget budget in currentUser.Budgets)
                {
                    if (budget.BudgetDate.Month == date.Month)
                    {
                        Expenses newExpense = new Expenses(name, amount, date, category);
                        newExpense.ExpenseId = budget.getNextId(budget.ListOfExpenses);
                        budget.AddExpense(newExpense);
                    }
                }
                UserManager.SaveLoggedInUserData();               
                await Navigation.PopModalAsync();
            }
            else
            {
               await DisplayAlert("Alert", "One or more required fields are empty. Please try again.", "OK");
            }
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            //expense.ExpenseId = 1;
            //foreach (Budget budget in currentUser.Budgets)
            //{
            //    if (budget.BudgetDate.Month == expense.ExpenseDate.Month)
            //    {
            //        budget.ListOfExpenses.RemoveAll(x => x.ExpenseId == expense.ExpenseId);
            //        DisplayAlert("Success", "Your expense has been deleted!", "OK");
            //    }
                
            //}
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            // Read the value that user has selected
            date = (DateTime)e.NewDate;
            if (date.Month != DateTime.Now.Month)
            {
                DisplayAlert("Warning!", "This item will not be visible under the current month's list", "OK");
            }
        }

        private void HomeIcon_Clicked(object sender, EventArgs e)
        {
            SetCategoryIcon(Category.Home);
        }

        private void ShoppingIcon_Clicked(object sender, EventArgs e)
        {
            SetCategoryIcon(Category.Shopping);
        }

        private void TravelIcon_Clicked(object sender, EventArgs e)
        {
            SetCategoryIcon(Category.Travel);
        }

        private void FoodIcon_Clicked(object sender, EventArgs e)
        {
            SetCategoryIcon(Category.Food);
        }

        private void EntertainmentIcon_Clicked(object sender, EventArgs e)
        {
            SetCategoryIcon(Category.Entertainment);
        }
                
        private void EducationIcon_Clicked(object sender, EventArgs e)
        {
            SetCategoryIcon(Category.Education);
        }

        private void BillsIcon_Clicked(object sender, EventArgs e)
        {
            SetCategoryIcon(Category.Bills);
        }

        private void GiftIcon_Clicked(object sender, EventArgs e)
        {
            SetCategoryIcon(Category.Gift);
        }

        private void DisableAllIcons()
        {
            HomeIcon.BackgroundColor = Color.LightGray;
            ShoppingIcon.BackgroundColor = Color.LightGray;
            TravelIcon.BackgroundColor = Color.LightGray;
            FoodIcon.BackgroundColor = Color.LightGray;
            EntertainmentIcon.BackgroundColor = Color.LightGray;
            EducationIcon.BackgroundColor = Color.LightGray;
            BillsIcon.BackgroundColor = Color.LightGray;
            GiftIcon.BackgroundColor = Color.LightGray;
        }

        private void SetCategoryIcon(Category category)
        {
            ExpenseCategory.Text = $"Category: {category}";
            DisableAllIcons();
            switch (category)
                {
                case Category.Home:
                    HomeIcon.BackgroundColor = Color.Aqua;
                    break;
                case Category.Shopping:
                    ShoppingIcon.BackgroundColor = Color.Aqua;
                    break;
                case Category.Travel:
                    TravelIcon.BackgroundColor = Color.Aqua;
                    break;
                case Category.Food:
                    FoodIcon.BackgroundColor = Color.Aqua;
                    break;
                case Category.Entertainment:
                    EntertainmentIcon.BackgroundColor = Color.Aqua;
                    break;
                case Category.Education:
                    EducationIcon.BackgroundColor = Color.Aqua;
                    break;
                case Category.Bills:
                    BillsIcon.BackgroundColor = Color.Aqua;
                    break;
                case Category.Gift:
                    GiftIcon.BackgroundColor = Color.Aqua;
                    break;
                }
                
        }

    }
    
}
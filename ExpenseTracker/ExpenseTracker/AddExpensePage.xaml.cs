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

        public string name;
        public string amount;
        public DateTime date;
        public Category category;

        protected override void OnAppearing()
        {
            var expense = (Expenses)BindingContext;
            if (!string.IsNullOrEmpty(expense.Description))
            {
                ExpenseLabel.Text = "Update Expense";
                ExpenseName.Text = expense.Description;
                ExpenseAmount.Text = expense.ExpenseAmount;
                //ExpenseDate = expense.ExpenseDate;
                ExpenseCategory.Text = expense.ExpenseCategory.ToString();
                //Highlight the selected category
                AddSaveButton.Text = "Update";
                DeleteButton.IsVisible = true;
            }
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            name = ExpenseName.Text;
            amount = ExpenseAmount.Text;

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(amount) && !string.IsNullOrWhiteSpace(category.ToString()))
            {
                

                // Hard coded values to create file name Tayal and set budget as $2000 

                //Budget currentBudget = new Budget(2000);
                //currentBudget.AddExpense(newExpense);

                //User testUser = new User("Tayal");
                //testUser.Budgets.Add(currentBudget);

                //var firstFile = JsonSerializer.Serialize(testUser);

                //FileManager fm = new FileManager();
                //fm.SaveDataToFile("Tayal", firstFile);

                FileManager fm = new FileManager();
                string readData = fm.ReadFileData("Tayal");
                User currentUserFile = JsonSerializer.Deserialize<User>(readData);

                foreach (Budget budget in currentUserFile.Budgets)
                {
                    if (budget.BudgetDate.Month == date.Month)
                    {
                        Expenses newExpense = new Expenses(name, amount, date, category);
                        newExpense.ExpenseId = budget.getNextId(budget.ListOfExpenses);
                        budget.AddExpense(newExpense);
                    }
                }
                var updatedExpenseJsonString = JsonSerializer.Serialize(currentUserFile);
                fm.SaveDataToFile("Tayal", updatedExpenseJsonString );
            }
            else
            {
                DisplayAlert("Alert", "One or more required fields are empty. Please try again.", "OK");
            }
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            // Read the value that user has selected
            date = (DateTime)e.NewDate;
            if (date.Month != DateTime.Now.Month)
            {
                DisplayAlert("Warning!", "This item will not be visible under the current month's list", "OK");
                //AddSaveButton.Text = "Edit";
            }
        }

        private void HomeIcon_Clicked(object sender, EventArgs e)
        {
            category = Category.Home;
            ExpenseCategory.Text = $"Category: {category}";
            IconsEnableDisable();
            HomeIcon.BackgroundColor = Color.Aqua;
        }

        private void ShoppingIcon_Clicked(object sender, EventArgs e)
        {
            category = Category.Shopping;
            ExpenseCategory.Text = $"Category: {category}";
            IconsEnableDisable();
            ShoppingIcon.BackgroundColor = Color.Aqua;
        }

        private void TravelIcon_Clicked(object sender, EventArgs e)
        {
            category = Category.Travel;
            ExpenseCategory.Text = $"Category: {category}";
            IconsEnableDisable();
            TravelIcon.BackgroundColor = Color.Aqua;
        }

        private void FoodIcon_Clicked(object sender, EventArgs e)
        {
            category = Category.Food;
            ExpenseCategory.Text = $"Category: {category}";
            IconsEnableDisable();
            FoodIcon.BackgroundColor = Color.Aqua;
        }

        private void EntertainmentIcon_Clicked(object sender, EventArgs e)
        {
            category = Category.Entertainment;
            ExpenseCategory.Text = $"Category: {category}";
            IconsEnableDisable();
            EntertainmentIcon.BackgroundColor = Color.Aqua;
        }

        private void EducationIcon_Clicked(object sender, EventArgs e)
        {
            category = Category.Education;
            ExpenseCategory.Text = $"Category: {category}";
            IconsEnableDisable();
            EducationIcon.BackgroundColor = Color.Aqua;
        }

        private void BillsIcon_Clicked(object sender, EventArgs e)
        {
            category = Category.Bills;
            ExpenseCategory.Text = $"Category: {category}";
            IconsEnableDisable();
            BillsIcon.BackgroundColor = Color.Aqua;
        }

        private void GiftIcon_Clicked(object sender, EventArgs e)
        {
            category = Category.Gift;
            ExpenseCategory.Text = $"Category: {category}";
            IconsEnableDisable();
            GiftIcon.BackgroundColor = Color.Aqua;
        }

        private void IconsEnableDisable()
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

        
    }
    
}
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
        Expenses expense = new Expenses("Cycle", 256, DateTime.Now.AddDays(-7), Category.Shopping);
        


        protected override void OnAppearing()
        {
            //var expense = (Expenses)BindingContext;
            //if (!string.IsNullOrEmpty(expense.Description))
            //{
            //    ExpenseLabel.Text = "Update Expense";
            //    ExpenseName.Text = expense.Description;
            //    ExpenseAmount.Text = expense.ExpenseAmount.ToString();
            //    ExpenseDate.Date = expense.ExpenseDate;
            //    ExpenseCategory.Text = $"Category: {expense.ExpenseCategory.ToString()}";
            //    //Highlight the selected category
            //    AddSaveButton.Text = "Update";
            //    DeleteButton.IsVisible = true;
            //}
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
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
                var updatedExpenseJsonString = JsonSerializer.Serialize(currentUser);
                FileManager.SaveDataToFile(currentUser.UserName, updatedExpenseJsonString );
                DisplayAlert("Success", "Your expense has been added!", "OK");
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
            expense.ExpenseId = 1;
            foreach (Budget budget in currentUser.Budgets)
            {
                if (budget.BudgetDate.Month == expense.ExpenseDate.Month)
                {
                    budget.ListOfExpenses.RemoveAll(x => x.ExpenseId == expense.ExpenseId);
                    DisplayAlert("Success", "Your expense has been deleted!", "OK");
                }
                
            }
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
            //category = Category.Food;
            //ExpenseCategory.Text = $"Category: {category}";
            //IconsEnableDisable();
            //FoodIcon.BackgroundColor = Color.Aqua;

            SetIconAndCategory(category, FoodIcon);
        }

        private void SetIconAndCategory(Category selectedCategory, ImageButton imageButton)
        {
            category = selectedCategory;
            ExpenseCategory.Text = $"Category: {category}";
            IconsEnableDisable();
            imageButton.BackgroundColor = Color.Aqua;
        }

        private void EntertainmentIcon_Clicked(object sender, EventArgs e)
        {
            category = Category.Entertainment;
            ExpenseCategory.Text = $"Category: {category}";
            IconsEnableDisable();
            EntertainmentIcon.BackgroundColor = Color.Aqua;

            //IconandCategory(Category.Entertainment);
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

        //private void IconandCategory(Category category)
        //{
        //    ImageButton imageButton;
        //    if (category == Category.Home)
        //    {
        //        ExpenseCategory.Text = $"Category: {category}";
        //        imageButton = HomeIcon;
        //        imageButton.BackgroundColor = Color.Aqua;
        //    }
        //    else if (category == Category.Shopping)
        //    {
        //        ExpenseCategory.Text = $"Category: {category}";
        //        imageButton = ShoppingIcon;
        //        imageButton.BackgroundColor = Color.Aqua;
        //    }
        //    else if (category == Category.Travel)
        //    {
        //        ExpenseCategory.Text = $"Category: {category}";
        //        imageButton = TravelIcon;
        //        imageButton.BackgroundColor = Color.Aqua;
        //    }
        //    else if (category == Category.Food)
        //    {
        //        ExpenseCategory.Text = $"Category: {category}";
        //        imageButton = FoodIcon;
        //        imageButton.BackgroundColor = Color.Aqua;
        //    }
        //    else if (category == Category.Entertainment)
        //    {
        //        ExpenseCategory.Text = $"Category: {category}";
        //        imageButton = EntertainmentIcon;
        //        imageButton.BackgroundColor = Color.Aqua;
        //    }
        //}

    }
    
}
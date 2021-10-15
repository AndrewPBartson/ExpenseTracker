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
            Budget currentBudget = new Budget();
            currentBudget.BudgetGoalAmount = float.Parse(BudgetInput.Text);
            currentBudget.BudgetDate = DateTime.Now;
            currentBudget.ListOfExpenses = new List<Expenses>();
            // currentBudget.BudgetMonth = DateTime.Now.ToString("MMMM");

            User testUser = new User();
            testUser.UserName = "Swati";
            testUser.Password = "123456";
            testUser.Budgets = new List<Budget>();
            testUser.Budgets.Add(currentBudget);

            // save data to file
            var firstFile = JsonSerializer.Serialize(testUser);
            FileManager fm = new FileManager();
            fm.SaveDataToFile("Swati", firstFile);

            // read data back from file
            string readData = fm.ReadFileData("Swati");
            User currentUserFile = JsonSerializer.Deserialize<User>(readData);

            // save data again
            var updatedExpenseJsonString = JsonSerializer.Serialize(currentUserFile);
            fm.SaveDataToFile("Swati", updatedExpenseJsonString);

            // read back again
            string s = fm.ReadFileData("Swati");
        }

        private void OnViewExpensesButtonClicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new ExpensePage
            //{
            //    //BindingContext = (Expense)e.SelectedItem
            //});

            // from onsavebuttonclicked
            //await Navigation.PushModalAsync(new ExpensePage
            //{
            //    BindingContext = (Expense)e.SelectedItem
            //});
        }
    }
}
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

        private async void OnEditButtonClicked(object sender, EventArgs e)
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
            await Navigation.PushModalAsync(new AddExpensePage());

        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Budget currentBudget = new Budget();
            currentBudget.BudgetGoalAmount = Convert.ToDecimal(BudgetInput.Text);
            currentBudget.BudgetDate = DateTime.Now;
            currentBudget.ListOfExpenses = new List<Expenses>();
            // currentBudget.BudgetMonth = DateTime.Now.ToString("MMMM");
            var currentUser = UserManager.GetLoggedInUser();
            User testUser = new User();
            testUser.UserName = "Swati";
            testUser.Password = "123456";
            currentUser.Budgets = new List<Budget>();
            currentUser.Budgets.Add(currentBudget);
           
            // save data to file
            //var firstFile = JsonSerializer.Serialize(testUser);
            //FileManager.SaveDataToFile(currentUser.UserName, firstFile);

            // read data back from file
            //string readData = FileManager.ReadFileData(currentUser.UserName);
            //User currentUserFile = JsonSerializer.Deserialize<User>(readData);

            // save data again
            var updatedExpenseJsonString = JsonSerializer.Serialize(currentUser);
            FileManager.SaveDataToFile(currentUser.UserName, updatedExpenseJsonString);

            // read back again
            string s = FileManager.ReadFileData(currentUser.UserName);
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
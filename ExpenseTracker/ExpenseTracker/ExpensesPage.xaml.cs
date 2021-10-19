using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        public ExpensesPage()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {


            Setting_SortPickerdata();


            List<Expenses> ExpenseList = new List<Expenses>();
            FileManagement CurrentData = new FileManagement();


            
            ExpenseList = CurrentData.ExpenseList_CurrentMonth();
            
            ExpensesListView.ItemsSource = null;
            ExpensesListView.ItemsSource = ExpenseList;
            
            decimal CurrentMonthCost = CurrentData.Calculate_MonthlyCost();
            decimal AmonthTOGoal= CurrentData.AmountToGoal();
           
            AmountLabel.Text = " Summery " + Convert.ToString(CurrentMonthCost);
            RemainedLable.Text = "Your Remained Amount   " + Convert.ToString(AmonthTOGoal);
            



        }
        

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void AddNewExpenses_Click(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddExpensePage
            {
                BindingContext = new Expenses()
            });
        }

        private  async void ShowMonthlyBudgetSummary_Click(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BudgetPage
            {
                BindingContext = new Budget()
            }) ;
        }

        private async void ExpensesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new AddExpensePage
            {
                BindingContext = (Expenses)e.SelectedItem
            });
        }

        private void Setting_SortPickerdata()
        {
            SortingPicker.ItemsSource= null;
            SortingPicker.Items.Add("Expense Date");
            SortingPicker.Items.Add("Price");
        }

        private void SortingSelectedItem_Click(object sender, EventArgs e)
        {
            List<Expenses> ExpenseList = new List<Expenses>();
            List<Expenses> SortExpenseList = new List<Expenses>();
            FileManagement CurrentData = new FileManagement();
    

            ExpenseList = CurrentData.ExpenseList_CurrentMonth();
            if (SortingPicker.SelectedIndex == 0)
            {


                SortExpenseList=ExpenseList.OrderBy(n => n.ExpenseDate).ToList();
                ExpensesListView.ItemsSource = null;
                ExpensesListView.ItemsSource = SortExpenseList;
            }
            else
            {
                SortExpenseList = ExpenseList.OrderBy(n => n.ExpenseAmount).ToList();
                ExpensesListView.ItemsSource = null;
                ExpensesListView.ItemsSource = SortExpenseList;
            }
        }
    }
}
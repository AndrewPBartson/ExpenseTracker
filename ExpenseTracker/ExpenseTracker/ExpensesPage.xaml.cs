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
            Setting_FilteringPickerData();

            List<Expenses> ExpenseList = new List<Expenses>();
            FileManagement CurrentData = new FileManagement();


            
            ExpenseList = CurrentData.ExpenseList_CurrentMonth();
            
            ExpensesListView.ItemsSource = null;
            ExpensesListView.ItemsSource = ExpenseList;
            
            decimal CurrentMonthCost = CurrentData.Calculate_MonthlyCost();
            decimal AmonthTOGoal= CurrentData.AmountToGoal();
           
            AmountLabel.Text = " Summary " + Convert.ToString(CurrentMonthCost);
            RemainedLable.Text = "Remaining Balance   " + Convert.ToString(AmonthTOGoal);
            



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
        
            SortingPicker.Items.Clear();
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

        private void Setting_FilteringPickerData()
        {

            FilteringPicker.Items.Clear();


            foreach (string name in Enum.GetNames(typeof(Category)))
            {
                FilteringPicker.Items.Add(name);
            }
            

           
        }


        private void FilteringPickerSelectedItem_Click(object sender, EventArgs e)
        {
            List<Expenses> ExpenseList = new List<Expenses>();
            List<Expenses> FilteredExpenseList = new List<Expenses>();
            FileManagement CurrentData = new FileManagement();

            //Category Categoryneme = (Category)e;

            //ExpenseList = CurrentData.ExpenseList_CurrentMonth();
            
            //    FilteredExpenseList = ExpenseList.Where(n => n.ExpenseCategory.ToString == ).ToList();
            //    ExpensesListView.ItemsSource = null;
            //    ExpensesListView.ItemsSource = FilteredExpenseList;
            
            
        }

        private void OnMonthBrows(object sender, EventArgs e)
        {

        }

        private void OnYearBrows(object sender, EventArgs e)
        {

        }
    }
}
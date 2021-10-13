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



            //var ExpensesList= new List<Expenses>
            //var FilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            //FilePath = FilePath + Costants.FileName;


            List<Expense> ExpenseList = new List<Expense>();
            FileManagement CurrentData = new FileManagement();

            ExpenseList = CurrentData.ExpenseList_CurrentMonth();
            ExpensesListView.ItemsSource = ExpenseList;
            double CurrentMonthCost = CurrentData.Calculate_MonthlyCost();

           
            AmountLabel.Text = "Monthly Summery is " + Convert.ToString(CurrentMonthCost);




    }

        
        private void AddNewExpenses_Click(object sender, EventArgs e)
        {

        }

        private void ShowMonthlyBudgetSummary_Click(object sender, EventArgs e)
        {

        }

        private void ExpensesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
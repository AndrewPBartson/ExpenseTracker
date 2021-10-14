using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ExpenseTracker.Model
{
    class FileManagement
    {   
        
        
        public void FileNameAssignment()
        {

            Costants.FileName = Costants.Currentuser.UserName.ToString() + Costants.CurretMonth.ToString() ;
        }

        public DataFile Load_All_Data()

        {
             var Filepath = Environment.CurrentDirectory + Costants.FileName+".json";

            //   var CurrentValidData = File.ReadAllText(Filepath);

          // List<DataFile> CurrentListdata = new List<DataFile>();
            DataFile Currentdata = new DataFile();

            Expense ExpenseItem1 = new Expense();
            Expense ExpenseItem2 = new Expense();
            Expense ExpenseItem3 = new Expense();
            List<Expense> ListExpenseItem = new List<Expense>();
            User CurrentUser = new User();
            MothlyGoal Budget = new MothlyGoal();

            CurrentUser.UserName = "Filicity";
            Budget.AmounthGoal = 3000.00;
            Budget.Monthes = Convert.ToDateTime("2021/10");

            //Currentdata.AppUser.UserName = "Filicity";
            //Currentdata.Budget.AmounthGoal = 3000.00;
            //Currentdata.Budget.Monthes = Convert.ToDateTime("2021/10");
            Currentdata.AppUser = CurrentUser;
            Currentdata.Budget = Budget;

            ExpenseItem1.ExpenseAmount = 100;
            ExpenseItem1.Expensecategory = Category.Home;
            ExpenseItem1.ExpenseDate = Convert.ToDateTime("2021/10/01");
            ExpenseItem1.ExpenseName = "Area Rug";


            ListExpenseItem.Add(ExpenseItem1);
           // Currentdata.Budget.expenses.Add(ExpenseItem);
            

            ExpenseItem2.ExpenseAmount = 100;
            ExpenseItem2.Expensecategory = Category.Grocery;
            ExpenseItem2.ExpenseDate = Convert.ToDateTime("2021/10/02");
            ExpenseItem2.ExpenseName = "Dairy";


            //Currentdata.Budget.expenses.Add(ExpenseItem);



            ListExpenseItem.Add(ExpenseItem2);
            ExpenseItem3.ExpenseAmount = 150;
            ExpenseItem3.Expensecategory = Category.Clothes;
            ExpenseItem3.ExpenseDate = Convert.ToDateTime("2021/10/04");
            ExpenseItem3.ExpenseName = "Jacket";
            ListExpenseItem.Add(ExpenseItem3);

            //Currentdata.Budget.expenses.Add(ExpenseItem);
            // CurrentListdata.Add(Currentdata);
            Currentdata.Budget.expenses = ListExpenseItem;

            return Currentdata;

        }

        public List<Expense> ExpenseList_CurrentMonth()
        {
             DataFile CurrentListdata = new DataFile();
            CurrentListdata = Load_All_Data();

            List<Expense> CurrentMonthExpense = new List<Expense>() ;

           return( CurrentListdata.Budget.expenses);

        }


        public double Calculate_MonthlyCost()
        {
            List<Expense> CurrentMonthExpense = new List<Expense>();
            CurrentMonthExpense = ExpenseList_CurrentMonth();

            double monthlyCost=0.00;

            foreach( var a in CurrentMonthExpense)
            {
                monthlyCost = monthlyCost + a.ExpenseAmount;


            }
            return monthlyCost;
        }
        

    }
}

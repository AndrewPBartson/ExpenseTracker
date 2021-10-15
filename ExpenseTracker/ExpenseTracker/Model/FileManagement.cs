using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace ExpenseTracker.Model
{
    class FileManagement
    {   
        
        
        

        


        public User Load_Data()
        {
            //SaveFile();
            FileManager file = new FileManager();
            string fileName = "Filcity202110";

            string jsonString = file.ReadFileData(fileName);
            User DataFile = JsonSerializer.Deserialize<User>(jsonString);

            
            return DataFile;


        }


        public void SaveFile()
        {
            FileManager file = new FileManager();
            User Currentdata = new User();
         
            Currentdata = Load_All_Data();
            //string fileName = "Filcity202110.json";

            string jsonString = JsonSerializer.Serialize(Currentdata);
            if (file.SaveDataToFile("Filcity202110", jsonString))
            {
               // mbox
            }

        }



        public List<Expenses> ExpenseList_CurrentMonth()
        {
           
            List<Expenses> CurrentMonthExpense = new List<Expenses>();
            List<Budget> Budgets = new List<Budget>();
            
            User CurrentListdata = Load_Data();
            Budgets = CurrentListdata.Budgets;
          
            var Budget = CurrentListdata.Budgets.Find(n => n.BudgetDate == Costants.CurretMonth);
            CurrentMonthExpense = Budget.Expenses;
            
            return (CurrentMonthExpense);

        }

        public decimal Calculate_MonthlyCost()
        {
            List<Expenses> CurrentMonthExpense = new List<Expenses>();
            CurrentMonthExpense = ExpenseList_CurrentMonth();

            decimal  monthlyCost= 0.0m;

            foreach( var a in CurrentMonthExpense)
            {
                if (a != null)
                {
                    monthlyCost = monthlyCost + a.ExpenseAmount;
                }
               }
            return monthlyCost;
        }


        public decimal AmountToGoal()
        {
            List<Expenses> CurrentMonthExpense = new List<Expenses>();
            List<Budget> Budgets = new List<Budget>();

            User CurrentListdata = Load_Data();
            Budgets = CurrentListdata.Budgets;

            var Budget = CurrentListdata.Budgets.Find(n => n.BudgetDate == Costants.CurretMonth);

            if (Budget != null)
            {
                decimal CurrentBudgetExpencess = Calculate_MonthlyCost();

                return (Budget.BudgetGoalAmount - CurrentBudgetExpencess);
            }
            return 0;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace ExpenseTracker.Model
{
    class FileManagement
    {   
        
             

        public List<Expenses> ExpenseList_CurrentMonth()
        {
            Costants.CurretMonth = DateTime.Today;



            List<Expenses> CurrentMonthExpense = new List<Expenses>();
            List<Budget> Budgets = new List<Budget>();
            
            User CurrentListdata = UserManager.GetLoggedInUser();
            Budgets = CurrentListdata.Budgets;
          
            var Budget = CurrentListdata.Budgets.Find(n => n.BudgetDate.Month == Costants.CurretMonth.Month);
            if (Budget != null)
            {
                CurrentMonthExpense = Budget.ListOfExpenses;
            }
                return (CurrentMonthExpense);
            
            
        }

        public decimal Calculate_MonthlyCost()
        {
            List<Expenses> CurrentMonthExpense = new List<Expenses>();
            CurrentMonthExpense = ExpenseList_CurrentMonth();

            decimal  monthlyCost= 0.0m;

            foreach( var Expense in CurrentMonthExpense)
            {
                if (Expense != null)
                {
                    monthlyCost = monthlyCost + Expense.ExpenseAmount;
                }
               }
            return monthlyCost;
        }


        public decimal AmountToGoal()
        {
            List<Expenses> CurrentMonthExpense = new List<Expenses>();
            List<Budget> Budgets = new List<Budget>();

            User CurrentListdata = UserManager.GetLoggedInUser();
            //Budgets = CurrentListdata.Budgets;

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

using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Model
{
    public class Budget
    {
        public float BudgetGoalAmount { get; set; }
        public List<Expenses> ListOfExpenses { get; set; }
        public DateTime BudgetDate { get; set; }

        //public Budget(string setBudget)
        //{
        //    BudgetGoalAmount = float.Parse(setBudget);
        //    BudgetDate = DateTime.Now;
        //    ListOfExpenses = new List<Expenses>();
        //}

        public List<Expenses> AddExpense(Expenses expobj)
        {
            return null;
        }

        public List<Expenses> EditExpense(Expenses expobj)
        {
            return null; 
        }

        public List<Expenses> DeleteExpense(Expenses expobj)
        { 
            return null;
        }
    }
}

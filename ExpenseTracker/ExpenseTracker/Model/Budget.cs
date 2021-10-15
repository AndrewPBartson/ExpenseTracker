using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Model
{
    public class Budget
    {
        public float BudgetGoalAmount { get; set; }
        public List<Expenses> Expenses { get; set; }
        public DateTime BudgetDate { get; set; }

        // Buget should allow you to Add expense, Edit Expense and Delete Expense


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

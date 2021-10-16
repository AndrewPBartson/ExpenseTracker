using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker.Model
{
    public class Budget
    {
        public decimal BudgetGoalAmount { get; set; }
        public List<Expenses> ListOfExpenses { get; set; }
        public DateTime BudgetDate { get; set; }

        // Buget should allow you to Add expense, Edit Expense and Delete Expense

        public Budget()
        {
            ListOfExpenses = new List<Expenses>();
        }

        public Budget(decimal setBudget)
        {
            BudgetGoalAmount = setBudget;
            BudgetDate = DateTime.Now;
            ListOfExpenses = new List<Expenses>();
        }

        public List<Expenses> AddExpense(Expenses expense)
        {
            ListOfExpenses.Add(expense);

            return ListOfExpenses;
        }

        public List<Expenses> EditExpense(Expenses expense)
        {
            return null;
        }

        public List<Expenses> DeleteExpense(Expenses expense)
        {
            ListOfExpenses.Remove(expense);
            return null;
        }
        public int getNextId(List<Expenses> expenses)
        {
            int nextId;
            Expenses lastExpense = expenses.LastOrDefault();
            if (lastExpense == null)
            {
                nextId = 0;
            }
            else
            {
                nextId = lastExpense.ExpenseId + 1;
            }
            return nextId;
        }
    }
}
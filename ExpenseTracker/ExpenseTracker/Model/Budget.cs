using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker.Model
{
    public class Budget : BaseEntity
    {
        private decimal budgetgoalamount;
        private List<Expenses> listofexpenses;
        private DateTime budgetdate;

        public decimal BudgetGoalAmount
        {
            get { return this.budgetgoalamount; }
            set
            {
                if (value != this.budgetgoalamount)
                {
                    this.budgetgoalamount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<Expenses> ListOfExpenses
        {
            get { return this.listofexpenses; }
            set
            {
                if (value != this.listofexpenses)
                {
                    this.listofexpenses = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime BudgetDate
        {
            get { return this.budgetdate; }
            set
            {
                if (value != this.budgetdate)
                {
                    this.budgetdate = value;
                    NotifyPropertyChanged();
                }
            }
        }


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

        //public List<Expenses> EditExpense(Expenses expense, Expenses newExpense)
        //{
        //    expense.Name = expense>text;   
        //    return null;
        //}

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
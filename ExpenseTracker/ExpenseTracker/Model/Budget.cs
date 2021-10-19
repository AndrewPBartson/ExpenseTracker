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
        private DateTime budgetmonth;

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

        public DateTime BudgetMonth
        {
            get { return this.budgetmonth; }
            set
            {
                if (value != this.budgetmonth)
                {
                    this.budgetmonth = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Budget()
        {
            BudgetGoalAmount = 0;
            ListOfExpenses = new List<Expenses>();
            BudgetDate = DateTime.Now;
            BudgetMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        public Budget(decimal setBudget)
        {
            BudgetGoalAmount = setBudget;
            ListOfExpenses = new List<Expenses>();
            BudgetDate = DateTime.Now;
            BudgetMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        public List<Expenses> AddExpense(Expenses expense)
        {
            ListOfExpenses.Add(expense);

            return ListOfExpenses;
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
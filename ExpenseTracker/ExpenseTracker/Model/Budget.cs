using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Model
{
    public class Budget
    {
        public decimal BudgetGoalAmount { get; set; }
        public List<Expenses> ExpenseList { get; set; }
        public DateTime BudgetDate { get; set; }
    }
}

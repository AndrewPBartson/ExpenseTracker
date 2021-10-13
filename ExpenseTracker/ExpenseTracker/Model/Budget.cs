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
       
    }
}

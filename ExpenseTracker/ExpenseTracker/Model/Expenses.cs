using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Model
{ 
    public enum Category
    {
        Home,
        Entertainment,
        Food,
        HealthAndFitness,
        Education,
        Shopping,
        Others
    }

    public class Expenses
    {
        public string Description { get; set; }
        public float ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public Category ExpenseCategory { get; set; }
    }
}

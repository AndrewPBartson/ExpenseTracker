using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Model
{

    public enum Category
    {
        Home,
        Shopping,
        Travel,
        Food,
        Entertainment,
        Education,
        Bills,
        Gift
    }

    public class Expenses
    {
        public int ExpenseId { get; set; }
        public string Description { get; set; }
        public float ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public Category ExpenseCategory { get; set; }
    }
}

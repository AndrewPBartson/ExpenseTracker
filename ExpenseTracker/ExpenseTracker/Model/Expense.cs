using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Model
{

    public enum Category {
        Home,
        Clothes,
        Shoes,
        Grocery
    };
    class Expense
    {
        public string ExpenseName { get; set; }
        public float ExpenseAmount { get; set; }

        public DateTime ExpenseDate { get; set; }
        public Category Expensecategory { get; set; } 

    }
}

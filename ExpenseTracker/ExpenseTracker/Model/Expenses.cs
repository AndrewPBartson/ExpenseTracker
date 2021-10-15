using System;

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
        public decimal ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public Category ExpenseCategory { get; set; }

        public Expenses()
        {
        }
        public Expenses(string name, decimal amount, DateTime date, Category category)
        {
            Description = name;
            ExpenseAmount = amount;
            ExpenseDate = date;
            ExpenseCategory = category;
        }
    }

}

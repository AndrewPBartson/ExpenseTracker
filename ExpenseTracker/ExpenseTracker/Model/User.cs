using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Model
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Budget> Budgets { get; set; }

    }
}

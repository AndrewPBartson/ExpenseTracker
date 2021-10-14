using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Model
{
    class MothlyGoal
    {
        public DateTime  Monthes{ get; set; }
        public double AmounthGoal { get; set; }
        public List<Expense> expenses { get; set; }

    }
}

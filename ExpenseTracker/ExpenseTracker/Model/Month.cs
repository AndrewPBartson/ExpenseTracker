using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Model
{
    class Month : BaseEntity
    {

        public string MonthName;
        public int MonthId;


        public Month(string monthname, int monthId)
        {
            MonthName = monthname;
            MonthId = monthId;


        }

        

    }

}

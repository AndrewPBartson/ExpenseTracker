 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExpensesTracker.Model
{
    public class FileManager
    {
        string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public string ReadFileData(string fileName)
        {
            // The File path for user
            string jsonFilePath= Path.Combine(this.defaultPath, $"{fileName.ToLower()}.json");

            // Get all the File names from Directory that match *.json pattern.
            var filePaths = Directory.EnumerateFiles(defaultPath, $"*.json");

            // IF there are any files in the directory, then search for file name
            if (filePaths != null && filePaths.Any())
            {
                var userFileFound = filePaths.Where(filepath => filepath.ToLower() == jsonFilePath.ToLower()).FirstOrDefault();
                if (!string.IsNullOrEmpty(userFileFound))
                {
                    return File.ReadAllText(jsonFilePath);
                }
            }
            return null;
        }

        public bool SaveDataToFile(string fileName, string data)
        {
            // Create File name
            var jsonFileName = $"{fileName.ToLower()}.json";
            File.WriteAllText(Path.Combine(this.defaultPath, jsonFileName), data);
            return true;
        }


        public void FileNameAssignment()
        {

            Costants.FileName = Costants.Currentuser.UserName.ToString() + Costants.CurretMonth.ToString();
        }

        public DataFile Load_All_Data()

        {
            var Filepath = Environment.CurrentDirectory + Costants.FileName + ".json";

            //   var CurrentValidData = File.ReadAllText(Filepath);

            // List<DataFile> CurrentListdata = new List<DataFile>();
            DataFile Currentdata = new DataFile();

            Expense ExpenseItem1 = new Expense();
            Expense ExpenseItem2 = new Expense();
            Expense ExpenseItem3 = new Expense();
            List<Expense> ListExpenseItem = new List<Expense>();
            User CurrentUser = new User();
            MothlyGoal Budget = new MothlyGoal();

            CurrentUser.UserName = "Filicity";
            Budget.AmounthGoal = 3000.00;
            Budget.Monthes = Convert.ToDateTime("2021/10");

            //Currentdata.AppUser.UserName = "Filicity";
            //Currentdata.Budget.AmounthGoal = 3000.00;
            //Currentdata.Budget.Monthes = Convert.ToDateTime("2021/10");
            Currentdata.AppUser = CurrentUser;
            Currentdata.Budget = Budget;

            ExpenseItem1.ExpenseAmount = 100;
            ExpenseItem1.Expensecategory = Category.Home;
            ExpenseItem1.ExpenseDate = Convert.ToDateTime("2021/10/01");
            ExpenseItem1.ExpenseName = "Area Rug";


            ListExpenseItem.Add(ExpenseItem1);
            // Currentdata.Budget.expenses.Add(ExpenseItem);


            ExpenseItem2.ExpenseAmount = 100;
            ExpenseItem2.Expensecategory = Category.Grocery;
            ExpenseItem2.ExpenseDate = Convert.ToDateTime("2021/10/02");
            ExpenseItem2.ExpenseName = "Dairy";


            //Currentdata.Budget.expenses.Add(ExpenseItem);



            ListExpenseItem.Add(ExpenseItem2);
            ExpenseItem3.ExpenseAmount = 150;
            ExpenseItem3.Expensecategory = Category.Clothes;
            ExpenseItem3.ExpenseDate = Convert.ToDateTime("2021/10/04");
            ExpenseItem3.ExpenseName = "Jacket";
            ListExpenseItem.Add(ExpenseItem3);

            //Currentdata.Budget.expenses.Add(ExpenseItem);
            // CurrentListdata.Add(Currentdata);
            Currentdata.Budget.expenses = ListExpenseItem;

            return Currentdata;

        }

        public List<Expenses> ExpenseList_CurrentMonth()
        {
            DataFile CurrentListdata = new DataFile();
            CurrentListdata = Load_All_Data();

            List<Expense> CurrentMonthExpense = new List<Expense>();

            return (CurrentListdata.Budget.expenses);

        }


        public double Calculate_MonthlyCost()
        {
            List<Expense> CurrentMonthExpense = new List<Expense>();
            CurrentMonthExpense = ExpenseList_CurrentMonth();

            double monthlyCost = 0.00;

            foreach (var a in CurrentMonthExpense)
            {
                monthlyCost = monthlyCost + a.ExpenseAmount;


            }
            return monthlyCost;
        }


    }
}

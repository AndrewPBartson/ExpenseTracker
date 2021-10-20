﻿using ExpenseTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetPage : ContentPage
    {
        public BudgetPage()
        {
            InitializeComponent();
        }

        private DateTime budgetDate = DateTime.Now;
        private User currentUser = UserManager.GetLoggedInUser();
        
        protected override void OnAppearing()
        {
            Budget currentBudget = getMatchingBudget(budgetDate);

            // populate data into Pickers and BudgetInput
            BudgetInput.Text = currentBudget.BudgetGoalAmount.ToString(System.Globalization.CultureInfo.InvariantCulture);
            BudgetStatusReport.Text = $"Spent ${0} of ${currentBudget.BudgetGoalAmount}";

            int monthId = budgetDate.Month;
            int yearId = budgetDate.Year;
            BudgetMonthPicker.SelectedIndex = monthId - 1;
            BudgetYearPicker.SelectedIndex = yearId - 2021;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Budget nextBudget = getMatchingBudget(budgetDate);

            nextBudget.BudgetGoalAmount = decimal.Parse(BudgetInput.Text);
            nextBudget.BudgetDate = budgetDate;

            UserManager.SaveLoggedInUserData();
            await Navigation.PushModalAsync(new ExpensesPage()); 
        }

        private async void OnViewExpensesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpensesPage { BindingContext = new Expenses() });  
            return;
        }
        public void OnMonthChosen(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                budgetDate = new DateTime(budgetDate.Year, selectedIndex + 1, 1);
            }
        }
        public void OnYearChosen(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                budgetDate = new DateTime(selectedIndex + 2021, budgetDate.Month, 1);
            };
        }
        private Budget getMatchingBudget(DateTime date)
        {
            bool isBudgetAvailable = false;
            Budget targetBudget = new Budget();

            foreach (Budget budget in currentUser.Budgets)
            {
                if (budget.BudgetDate.Month == date.Month)
                {
                    isBudgetAvailable = true;
                    targetBudget = budget;
                    break;
                }
            }
            if (isBudgetAvailable == false)
            {
                targetBudget.BudgetGoalAmount = 0;
                targetBudget.BudgetDate = date;
                currentUser.Budgets.Add(targetBudget);
            }
            return targetBudget;
        }
    }
}
using ExpenseTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ExpenseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpensePage : ContentPage
    {
        public AddExpensePage()
        {
            InitializeComponent();
            CategoryIcon.getAllIcons();
        }

        public string name;
        public string amount;
        public DateTime date;
        public string category;
        //protected override void OnAppearing()
        //{
        //    //Code to check if the values need to be pre-populated by reading from the file.
        //}

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            name = ExpenseName.Text;
            amount = ExpenseAmount.Text;

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(amount) && !string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("The name of the expense is: " + name);
                Console.WriteLine("The amount of expense is: " + amount);
                Console.WriteLine("The date selected is: " + date);
                Console.WriteLine("The category selected is: " + category);
            }
            else
            {
                DisplayAlert("Alert", "One or more required fields are empty. Please try again.", "OK");
            }
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            // Read the value that user has selected
            date = (DateTime)e.NewDate;
            
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void HomeIcon_Clicked(object sender, EventArgs e)
        {
            category = "Home";
            CategoryLabel.Text = $"Category: {category}";
            IconsEnableDisable();
            HomeIcon.BackgroundColor = Color.Aqua;
        }

        private void ShoppingIcon_Clicked(object sender, EventArgs e)
        {
            category = "Shopping";
            CategoryLabel.Text = $"Category: {category}";
            IconsEnableDisable();
            ShoppingIcon.BackgroundColor = Color.Aqua;
        }

        private void TravelIcon_Clicked(object sender, EventArgs e)
        {
            category = "Travel";
            CategoryLabel.Text = $"Category: {category}";
            IconsEnableDisable();
            TravelIcon.BackgroundColor = Color.Aqua;
        }

        private void FoodIcon_Clicked(object sender, EventArgs e)
        {
            category = "Food";
            CategoryLabel.Text = $"Category: {category}";
            IconsEnableDisable();
            FoodIcon.BackgroundColor = Color.Aqua;
        }

        private void EntertainmentIcon_Clicked(object sender, EventArgs e)
        {
            category = "Entertainment";
            CategoryLabel.Text = $"Category: {category}";
            IconsEnableDisable();
            EntertainmentIcon.BackgroundColor = Color.Aqua;
        }

        private void EducationIcon_Clicked(object sender, EventArgs e)
        {
            category = "Education";
            CategoryLabel.Text = $"Category: {category}";
            IconsEnableDisable();
            EducationIcon.BackgroundColor = Color.Aqua;
        }

        private void BillsIcon_Clicked(object sender, EventArgs e)
        {
            category = "Bills";
            CategoryLabel.Text = $"Category: {category}";
            IconsEnableDisable();
            BillsIcon.BackgroundColor = Color.Aqua;
        }

        private void GiftIcon_Clicked(object sender, EventArgs e)
        {
            category = "Gift";
            CategoryLabel.Text = $"Category: {category}";
            IconsEnableDisable();
            GiftIcon.BackgroundColor = Color.Aqua;
        }

        private void IconsEnableDisable()
        {
            HomeIcon.BackgroundColor = Color.LightGray;
            ShoppingIcon.BackgroundColor = Color.LightGray;
            TravelIcon.BackgroundColor = Color.LightGray;
            FoodIcon.BackgroundColor = Color.LightGray;
            EntertainmentIcon.BackgroundColor = Color.LightGray;
            EducationIcon.BackgroundColor = Color.LightGray;
            BillsIcon.BackgroundColor = Color.LightGray;
            GiftIcon.BackgroundColor = Color.LightGray;
        }

        
    }
    
}
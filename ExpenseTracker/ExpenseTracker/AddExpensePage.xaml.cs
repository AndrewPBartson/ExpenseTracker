using System;
using System.Collections.Generic;
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
        }

        //protected override void OnAppearing()
        //{
        //    //Code to check if the values need to be pre-populated by reading from the file.
        //}

        private void OnAddButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            // Read the value that user has selected
            var date = (DateTime)e.NewDate;
            Console.WriteLine("The date selected is: " + date);
        }
       }
    
}
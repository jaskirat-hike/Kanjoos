using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLite;
using System.IO;
using Windows.Storage;

namespace Kanjoos
{
    public partial class Transaction : PhoneApplicationPage
    {
        // database path
        public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "kanjoos_db.sqlite"));

        // SQLite connection
        private SQLiteConnection dbConn;

        public Transaction()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // create db connection
            dbConn = new SQLiteConnection(DB_PATH);

            // create table if doesn't exist
            dbConn.CreateTable<Expenses>();
            dbConn.CreateTable<Balance>();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // close db connection
            if (dbConn != null)
                dbConn.Close();
        }

        private void add_expense_Click(object sender, RoutedEventArgs e)
        {
            // extract values for expense
            double amount = Convert.ToDouble(expense_amount.Text);
            string category = expense_category.Text;
            string detail = expense_detail.Text;

            // create a new expense record
            Expenses new_expense = new Expenses()
            {
                date = DateTime.Now,
                month = DateTime.Now.Month,
                category = category,
                detail = detail,
                amount = amount
            };

            // insert new record in table
            dbConn.Insert(new_expense);

            // navigate back to main page
            Uri mainPage = new Uri("/MainPage.xaml", UriKind.Relative);
            NavigationService.Navigate(mainPage);
        }

        private void add_income_Click(object sender, RoutedEventArgs e)
        {
            // extract value for income
            double amount = Convert.ToDouble(income_amount.Text);

            // retrieve previous income
            SQLiteCommand sqlCommand = new SQLiteCommand(dbConn);
            sqlCommand.CommandText = "SELECT amount FROM balance";
            List<Balance> balance = sqlCommand.ExecuteQuery<Balance>();

            // navigate back to main page
            Uri mainPage = new Uri("/MainPage.xaml", UriKind.Relative);
            NavigationService.Navigate(mainPage);
        }
    }
}
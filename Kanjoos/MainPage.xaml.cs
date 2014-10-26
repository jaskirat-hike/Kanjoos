using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Kanjoos.Resources;
using System.IO;
using Windows.Storage;
using SQLite;

namespace Kanjoos
{
    public partial class MainPage : PhoneApplicationPage
    {

        // database path
        public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "kanjoos_db.sqlite"));

        // SQLite connection
        private SQLiteConnection dbConn;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // create db connection
            dbConn = new SQLiteConnection(DB_PATH);
            
            // create new table if it doesn't exist
            dbConn.CreateTable<Expenses>();
            dbConn.CreateTable<Balance>();


            // retrieve records for current month
            int current_month = DateTime.Now.Month;

            List<Expenses> records = new List<Expenses>();
            records = RetrieveCurrentRecords(current_month);

            //List<Expenses> records = RetrieveCurrentRecords(int current_month);

            // construct various pages
            make_overview(records, current_month);
            make_expenditures(records);
        }

        private List<Expenses> RetrieveCurrentRecords(int month)
        {
            SQLiteCommand sqlCommand = new SQLiteCommand(dbConn);
            sqlCommand.CommandText = "SELECT * FROM expenses WHERE month = " + month.ToString();

            // retrieve records
            List<Expenses> records = sqlCommand.ExecuteQuery<Expenses>();
            return records;
        }

        // construct and update the overview page
        private void make_overview(List<Expenses> records, int current_month)
        {
            // calculate balance
            double cash_in_hand = 0.0;
            SQLiteCommand sqlCommand = new SQLiteCommand(dbConn);
            sqlCommand.CommandText = "SELECT * FROM balance WHERE id = 1";
            List<Balance> balance = sqlCommand.ExecuteQuery<Balance>();

            if (balance.Count == 0)
            {
                sqlCommand.CommandText = "INSERT INTO balance (id, amount) VALUES (1, 0.0)";
                sqlCommand.ExecuteQuery<Balance>();
            }
            else
                cash_in_hand = balance[0].amount;

            tb_balance.Text = "₹ " + cash_in_hand.ToString();


            // calculate expenditures
            double total_expenditure = 0.0;
            string month = Expenses.GetMonthName(current_month);

            // calc total expenditure of current month
            foreach (Expenses ex in records)
                total_expenditure += ex.amount;

            Dictionary<string, double> cat_expenses = new Dictionary<string, double>();
            cat_expenses = categorise_records(records);

            var sortedDict = from entry in cat_expenses orderby entry.Value descending select entry;

            List<CatExpenses> percent_expenses = new List<CatExpenses>();
            List<CatExpenses> top_expenses = new List<CatExpenses>();

            int item_index = 0;

            foreach (var rec in sortedDict)
            {
                CatExpenses new_item = new CatExpenses();
                new_item.category = rec.Key;
                new_item.amount = rec.Value;
                new_item.color = CatExpenses.GetColor(item_index); 
                new_item.percent = (int)((rec.Value / total_expenditure) * 100);
                percent_expenses.Add(new_item);

                if (top_expenses.Count < 2)
                    top_expenses.Add(new_item);
                item_index += 1;
            }

            lls_top_expenses.ItemsSource = top_expenses;
            
            
            // make pie chart from percent expenses
            make_breakup(percent_expenses);

            tb_expenditure.Text = "₹ " + total_expenditure.ToString();
            tb_current_month.Text = month.ToUpper();
        }

        // categorise records
        private Dictionary<string, double> categorise_records(List<Expenses> records)
        {
            Dictionary<string, double> cat_expenses = new Dictionary<string, double>();

            foreach (Expenses ex in records)
            {
                if (cat_expenses.ContainsKey(ex.category))
                    cat_expenses[ex.category] += ex.amount;
                else
                    cat_expenses.Add(ex.category, ex.amount);
            }

            return cat_expenses;
        }


        // construct and update the expenditures page
        private void make_expenditures(List<Expenses> records)
        {
            lls_expenses.ItemsSource = records;
        }

        // overloaded method for generating expenditures
        private void make_expenditures(int month)
        {
            // retrieve expenses of chosen month from DB
            List<Expenses> records = RetrieveCurrentRecords(month);
            make_expenditures(records);
        }
        
        // construct and update the breakup
        private void make_breakup(List<CatExpenses> records)
        {
            int item_count = records.Count;
            int item = 0;
            int[] breakup_percentages = new int[item_count];

            foreach (var rec in records)
            {
                breakup_percentages[item] = rec.percent;
                item += 1;
            }

            pie_breakup.Series[0].ItemsSource = breakup_percentages;

            lls_breakup.ItemsSource = records;
            //pie_breakup.Series[0].ItemsSource = records;

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // close the db connection
            if (dbConn != null)
                dbConn.Close();
        }

        private void apb_btn_addTrans_Click(object sender, EventArgs e)
        {
            // navigate to add transaction page
            Uri addTransPageURI = new Uri("/Transaction.xaml", UriKind.Relative);
            NavigationService.Navigate(addTransPageURI);
        }
    }
}
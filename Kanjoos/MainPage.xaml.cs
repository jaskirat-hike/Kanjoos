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

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // create db connection
            dbConn = new SQLiteConnection(DB_PATH);
            
            // create new table if it doesn't exist
            dbConn.CreateTable<Expenses>();

            // retrieve expenses from db
            List<Expenses> expenses = dbConn.Table<Expenses>().ToList<Expenses>();

            expenditures.Items.Clear();
            foreach (var t in expenses)
                expenditures.Items.Add(t);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // close the db connection
            if (dbConn != null)
                dbConn.Close();
        }


        // Building an Application bar
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton addTransaction = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            //appBarButton.Text = AppResources.AppBarButtonText;
            addTransaction.Text = "add";
            ApplicationBar.Buttons.Add(addTransaction);

            // Create a new menu item with the localized string from AppResources.
            //ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //ApplicationBar.MenuItems.Add(appBarMenuItem);
        }


        // temp function for adding transaction
        private void add_trans_Click(object sender, RoutedEventArgs e)
        {
            // navigate to add transaction page
            Uri addTransPageURI = new Uri("/Transaction.xaml", UriKind.Relative);
            NavigationService.Navigate(addTransPageURI);
        }
    }
}
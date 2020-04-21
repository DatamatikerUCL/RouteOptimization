using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelateITWorking.Models;
using RelateITWorking.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelateITWorking.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchSQLPage : ContentPage
    {
        private DatabaseAccess dbAccess;
        private LoginViewmodel loginVM;
        private User user;
        private List<User> users;
        public SearchSQLPage()
        {
            InitializeComponent();

            dbAccess = new DatabaseAccess();
            loginVM = new LoginViewmodel();
            user = new User();
            users = new List<User>();

        }


        private async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            // læg bruger i databasen uden validering

        }
    }
}
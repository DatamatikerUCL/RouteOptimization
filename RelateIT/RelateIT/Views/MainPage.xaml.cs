using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelateIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(int id)
        {
            InitializeComponent();
        }

        private void Btn_RouteOverView_Clicked(object sender, EventArgs e)
        {

        }

        private void Btn_CreateNewRoute_Clicked(object sender, EventArgs e)
        {

        }
    }
}
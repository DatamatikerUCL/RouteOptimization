using RelateIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelateIT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RouteOverview : ContentPage
    {
        public IList<RoutePlanned> Routes;
        public RouteOverview()
        {
            Routes = new List<RoutePlanned>();
            InitializeComponent();
            PopulateListView();
            

        }

        public void PopulateListView()
        {


            BindingContext = this;
        }
    }
}
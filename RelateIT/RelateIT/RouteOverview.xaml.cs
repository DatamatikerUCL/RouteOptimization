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
        public IList<Route> Routes;
        public RouteOverview()
        {
            Routes = new List<Route>();
            InitializeComponent();
            PopulateListView();
            

        }

        public void PopulateListView()
        {
            Routes.Add(new Route
            {
                Name = "Test Route",
                StartLocation = new Point(55.499680, 10.096780),
                EndLocation = new Point(55.403450, 10.379370),
                EstimatedTime = 4
            });

            BindingContext = this;
        }
    }
}
using RelateIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelateIT.Interfaces;
using RelateITWorking;
using RouteOptimization.RoutePlanner.Datastructures;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelateIT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RouteOverview : ContentPage
    {

        public RouteOverview(IDataAccessable dataAccesser)
        {
            InitializeComponent();
            BindingContext = dataAccesser.GetRoutes().ToList();
        }


    }
}
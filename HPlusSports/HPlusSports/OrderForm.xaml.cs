using HPlusSports.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HPlusSports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderForm : TabbedPage
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        public OrderForm(Order target)
        {
            InitializeComponent();
            BindingContext = target;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Order o = BindingContext as Order;
            DisplayAlert("Order Placed", $"Order placed for {o.Quantity} of {o.ProductName}", "OK");
        }
    }
}
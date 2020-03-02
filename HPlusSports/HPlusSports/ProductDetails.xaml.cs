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
    public partial class ProductDetails : ContentPage
    {
        public ProductDetails()
        {
            InitializeComponent();
        }

        public ProductDetails(Services.Product product)
        {
            InitializeComponent();
            BindingContext = product;
        }

        private void orderBtn_Clicked(object sender, EventArgs e)
        {
            Services.Product p = BindingContext as Services.Product;
            Navigation.PushAsync(new OrderForm(new Services.Order { ProductName = p.Name, Quantity = 1 }));
        }
    }
}
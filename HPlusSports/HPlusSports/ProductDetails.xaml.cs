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

            if (Services.ProductService.WishList.Any(item => item.Name == product.Name))
            {
                favoritbtn.IsEnabled = false;
                Unsubscribe.IsVisible = true;

            }
            else
            {
                favoritbtn.IsEnabled = true;
                Unsubscribe.IsVisible = false;
            }
        }

        private void orderBtn_Clicked(object sender, EventArgs e)
        {
            Services.Product p = BindingContext as Services.Product;
            Navigation.PushAsync(new OrderForm(new Services.Order { ProductName = p.Name, Quantity = 1 }));
        }

        private void favoriteBtn_Clicked(object sender, EventArgs e)
        {
            Services.Product p = BindingContext as Services.Product;
            if (Services.ProductService.WishList.Any(item => item.Name == p.Name))
            {
                DisplayAlert("Already contains this item", $"Your favorits list already contain {p.Name}", "OK");
            }
            else
            {
                Services.ProductService.WishList.Add(p);
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Services.Product p = BindingContext as Services.Product;
            Services.ProductService.RemoveProductFromWishList(p);
            DisplayAlert("Removed", $"{p.Name} has been removed from your wishlist", "Ok");
            Navigation.PopAsync();
        }
    }
}
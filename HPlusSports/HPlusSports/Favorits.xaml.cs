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
    public partial class Favorits : ContentPage
    {
        public Favorits()
        {
            InitializeComponent();
        }

        public Favorits(List<Product> wishList)
        {
            InitializeComponent();
            BindingContext = wishList;
        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Services.Product product = e.CurrentSelection.First() as Services.Product;
            Navigation.PushAsync(new ProductDetails(product));
        }
    }
}
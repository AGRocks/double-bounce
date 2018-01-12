using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using traininghub.mobile.ViewModels;
using traininghub.mobile.models;

namespace traininghub.mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Game
            {
                Sport = "Squash",
                VenueName = "Hasta"
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}
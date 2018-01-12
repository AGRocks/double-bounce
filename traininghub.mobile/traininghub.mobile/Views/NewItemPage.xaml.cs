using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using traininghub.mobile.models;

namespace traininghub.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Game Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Game
            {
                Sport = "Squash",
                VenueName = "Hasta"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}
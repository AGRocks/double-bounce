using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using traininghub.mobile.models;
using System.Collections.Generic;

namespace traininghub.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        private List<string> venues;

        public List<string> Venues => this.venues ?? (this.venues = new List<string> { "Hasta", "Redeco", "Jupiter", "Dlugosza" });

        public Game Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Game
            {
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
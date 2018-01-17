using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using traininghub.mobile.models;
using traininghub.mobile.ViewModels;

namespace traininghub.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        private readonly NewItemViewModel viewModel;

        public NewItemPage()
        {
            InitializeComponent();

            var newGame  = new Game
            {
                VenueName = "Hasta",
                Date = DateTime.Now,
                Duration = TimeSpan.FromMinutes(60),
                OrganizerId = 2,   
                Sport = "Squash",
                Status = "Active",
                VenueId = 1,
                NumberOfPlayers = 2                
            };

            BindingContext = viewModel = new NewItemViewModel(newGame);
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", this.viewModel.Game.Dto);
            await Navigation.PopModalAsync();
        }
    }
}
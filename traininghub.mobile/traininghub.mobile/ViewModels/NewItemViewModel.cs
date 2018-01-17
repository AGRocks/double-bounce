using System;
using System.Collections.Generic;
using System.Text;
using traininghub.mobile.models;

namespace traininghub.mobile.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private List<string> venues;

        public List<string> Venues => this.venues ?? (this.venues = new List<string> { "Hasta", "Redeco", "Jupiter", "Dlugosza" });

        public NewItemViewModel(Game newGame)
        {
            this.Game = new GameViewModel(newGame);
        }

        public GameViewModel Game { get; set; }

        public bool CanSave =>
            Game != null
            && Game.Date != null
            && Game.Duration > TimeSpan.FromMinutes(30)
            && !string.IsNullOrEmpty(Game.VenueName);
    }
}

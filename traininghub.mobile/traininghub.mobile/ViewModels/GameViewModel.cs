using System;
using System.Collections.Generic;
using System.Text;
using traininghub.mobile.models;

namespace traininghub.mobile.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private readonly Game gameDto;

        public GameViewModel()
        {
            this.gameDto = new Game();
        }

        public GameViewModel(Game gameDto)
        {
            this.gameDto = gameDto;
        }

        public Game Dto => this.gameDto;

        public DateTime Date
        {
            get
            {
                return this.gameDto.Date;
            }

            set
            {
                this.gameDto.Date = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return this.gameDto.Duration;
            }

            set
            {
                this.gameDto.Duration = value;
                OnPropertyChanged();
            }
        }

        public string VenueName
        {
            get
            {
                return this.gameDto.VenueName;
            }

            set
            {
                this.gameDto.VenueName = value;
            }
        }

    }
}

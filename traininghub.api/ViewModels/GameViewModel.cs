using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traininghub.Data;

namespace traininghub.api.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public Sport Sport { get; set; }
        public int NumberOfPlayers { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int VenueId { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public Status Status { get; set; }
        public int UserId { get; set; }
    }
}

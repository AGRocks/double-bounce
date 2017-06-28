using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Traininghub.Data
{
    public class Game
    {
        public int Id { get; set; }
        public Sport Sport { get; set; }
        public int NumberOfPlayers { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int VenueId { get; set; }
        public SkillLevel SkillLevel { get; set; }

        [ForeignKey("VenueId")]
        public virtual Venue Venue { get; set; }

        public virtual ICollection<AcceptedGameInvitation> AcceptedGameInvitations { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

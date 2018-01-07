using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Traininghub.Data
{
    public class Game : IClientEntity
    {
        public int Id { get; set; }
        public Sport Sport { get; set; }
        public int NumberOfPlayers { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int VenueId { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public Status Status { get; set; }
        public int OrganizerId { get; set; }
        
        public virtual User Organizer { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<Challenge> Challenges { get; set; }
    }
}

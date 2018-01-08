using System;

namespace traininghub.mobile.models
{
    public class Game
    {
        public int Id { get; set; }
        public string Sport { get; set; }
        public int NumberOfPlayers { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public string VenueName { get; set; }
        public string SkillLevel { get; set; }
        public string Status { get; set; }
        public int OrganizerId { get; set; }
        public string OrganizerName { get; set; }
    }
}

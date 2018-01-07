using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traininghub.Data
{
    public class Challenge : IClientEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ChallengeTime { get; set; }
        public int GameId { get; set; }
        public bool IsConfirmed { get; set; }

        public virtual User User { get; set; }
        public virtual Game Game { get; set; }
    }
}
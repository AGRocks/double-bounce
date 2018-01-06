using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traininghub.Data
{
    public class AcceptedGameInvitation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime AcceptedTime { get; set; }
    }
}
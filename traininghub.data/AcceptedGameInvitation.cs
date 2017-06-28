using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traininghub.Data
{
    public class AcceptedGameInvitation
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public DateTime AcceptedTime { get; set; }
    }
}
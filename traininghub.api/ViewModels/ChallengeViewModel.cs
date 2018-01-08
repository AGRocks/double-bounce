using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace traininghub.api.ViewModels
{
    public class ChallengeViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ChallengeTime { get; set; }
        public int GameId { get; set; }
        public bool IsConfirmed { get; set; }
        public string UserName { get; set; }
        public int OrganizerId { get; set; }
    }
}

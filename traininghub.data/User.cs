using System;
using System.Collections.Generic;

namespace Traininghub.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public Sport FavoriteSport { get; set; }
        public bool IsActivated { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}

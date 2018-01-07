using System;
using System.Collections.Generic;
using System.Text;

namespace Traininghub.Data
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyHome.Domain.Models
{
    public class Host : User
    {
        public ICollection<Accommodation> Accommodations { get; private set; }
               = new List<Accommodation>();

        private Host()
        {
        }

        public Host(string name, string email)
            : base(name, email)
        {
        }
    }
}

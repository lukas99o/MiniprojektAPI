﻿using System.Security.Principal;

namespace MiniprojektAPITakeTwo.Models
{
    public class Interest
    {
        public int InterestID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<InterestLink> InterestLinks { get; set; }
    }
}

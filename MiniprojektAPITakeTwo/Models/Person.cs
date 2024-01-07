namespace MiniprojektAPITakeTwo.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<InterestLink> InterestLinks { get; set; }
    }
}

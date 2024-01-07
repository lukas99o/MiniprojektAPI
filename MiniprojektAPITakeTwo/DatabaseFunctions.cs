using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MiniprojektAPITakeTwo.Data;
using MiniprojektAPITakeTwo.Models;
using System.Text;

namespace MiniprojektAPITakeTwo
{
    public static class DatabaseFunctions
    {
        public static void MakeInterests()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<Interest> interests = new List<Interest>();

                Interest football = new Interest()
                {
                    Title = "Football",
                    Description = "Get the ball inside the opponents net!"
                };

                Interest basketball = new Interest()
                {
                    Title = "Basketball",
                    Description = "Kooby"
                };

                interests.Add(football);
                interests.Add(basketball);

                context.Interests.AddRange(interests);
                context.SaveChanges();
            }
        }

        public static void MakePeople()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                List<Person> people = new List<Person>();

                Person liam = new Person()
                {
                    Name = "Liam Jarny",
                    PhoneNumber = "010-231-1233",
                };

                Person simon = new Person()
                {
                    Name = "Simon Johansson",
                    PhoneNumber = "4523-123-654"
                };

                Person lisa = new Person()
                {
                    Name = "Lisa Lundell",
                    PhoneNumber = "145-5344-865"
                };

                people.Add(liam);
                people.Add(simon);
                people.Add(lisa);

                context.People.AddRange(people);
                context.SaveChanges();
            }
        }

        public static void AssignPersonToInterest()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Console.WriteLine("You will now assign a interest to a person\n");

                Console.Write("Please insert PersonID: ");
                int personID = int.Parse(Console.ReadLine());

                var person = context.People.SingleOrDefault(p => p.PersonID == personID);

                if (person != null)
                {
                    Console.Write("Please insert InterestID: ");
                    int interestID = int.Parse(Console.ReadLine());

                    var interest = context.Interests.SingleOrDefault(i => i.InterestID == interestID);

                    if (interest != null)
                    {
                        if (person.Interests == null)
                        {
                            person.Interests = new List<Interest>();
                        }

                        person.Interests.Add(interest);
                        context.SaveChanges();
                    }
                }
            }
        }

        public static void PeopleWithInterest()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var peopleWithInterests = context.People
                .Include(p => p.Interests)
                .Where(p => p.Interests.Any())
                .ToList();

                foreach (var person in peopleWithInterests)
                {
                    Console.WriteLine($"Person: {person.Name}, Interests: {string.Join(", ", person.Interests.Select(i => i.Title))}");
                }
            }
        }

        public static void MakeLinks()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Console.WriteLine("You will now make a link for a interest and a person\n");

                Console.Write("Please insert PersonID: ");
                int personID = int.Parse(Console.ReadLine());
                Console.Write("Please insert InterestID: ");
                int interestID = int.Parse(Console.ReadLine());
                Console.Write("Please insert the Link: ");
                string link = Console.ReadLine();

                InterestLink newLink = new InterestLink()
                {
                    PersonID = personID,
                    InterestID = interestID,
                    Link = link
                };

                Console.WriteLine("Successfully Created Link.");
                context.InterestLinks.Add(newLink);
                context.SaveChanges();
            }
        }
    }
}

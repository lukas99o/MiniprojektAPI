using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MiniprojektAPITakeTwo.Data;
using MiniprojektAPITakeTwo.Models;
using MiniprojektAPITakeTwo.Dto;
using System.Text;

namespace MiniprojektAPITakeTwo
{
    public static class APIFunctions
    {
        public static string GetAllPeople(ApplicationContext context)
        {
            StringBuilder result = new StringBuilder();

            foreach (var person in context.People)
            {
                result.AppendLine($"PersonID: {person.PersonID},\tName: {person.Name}");
            }

            return result.ToString();
        }

        public static List<Interest> GetInterestsForPerson(ApplicationContext context, int personID)
        {
            var person = context.People
                .Include(p => p.Interests)
                .SingleOrDefault(p => p.PersonID == personID);

            if (person != null)
            {
                return person.Interests.ToList();
            }

            return new List<Interest>();
        }

        public static List<InterestLink> GetLinksForPerson(ApplicationContext context, int personID)
        {
            var person = context.People
                .Include(p => p.InterestLinks)
                .SingleOrDefault(p => p.PersonID == personID);

            if (person != null)
            {
                return person.InterestLinks.ToList();
            }

            return new List<InterestLink>();
        }

        public static IActionResult AssignInterest(ApplicationContext context, int personID, int interestID)
        {
            var person = context.People.Find(personID);
            var interest = context.Interests.Find(interestID);

            if (person == null || interest == null)
            {
                return new NotFoundObjectResult("Person or interest not found");
            }

            if (person.Interests == null)
            {
                person.Interests = new List<Interest>();
            }

            if (person.Interests.Contains(interest))
            {
                return new BadRequestObjectResult("person already has this interest.");
            }

            person.Interests.Add(interest);
            context.SaveChanges();

            return new OkObjectResult("Interest assigned successfully");
        }

        public static IActionResult CreateInterestLink(ApplicationContext context, CreateInterestLinkDto linkDto)
        {
            var person = context.People.Find(linkDto.PersonID);
            var interest = context.Interests.Find(linkDto.InterestID);

            if (person == null || interest == null)
            {
                return new NotFoundObjectResult("Person or interest not found");
            }

            var existingLink = context.InterestLinks
                .FirstOrDefault(link => link.PersonID == linkDto.PersonID && link.InterestID == linkDto.InterestID);

            if (existingLink != null)
            {
                return new BadRequestObjectResult("Link already exists for this person and interest");
            }

            var newLink = new InterestLink
            {
                PersonID = linkDto.PersonID,
                InterestID = linkDto.InterestID,
                Link = linkDto.Link
            };

            context.InterestLinks.Add(newLink);
            context.SaveChanges();

            return new OkObjectResult("Link created successfully");
        }
    }
}

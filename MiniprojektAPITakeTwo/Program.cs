using Microsoft.EntityFrameworkCore;
using MiniprojektAPITakeTwo.Data;
using MiniprojektAPITakeTwo.Dto;
using MiniprojektAPITakeTwo.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MiniprojektAPITakeTwo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
            builder.Services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/people", () =>
            {
                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                    var peopleResult = APIFunctions.GetAllPeople(context);

                    return Results.Text(peopleResult, "text/plain");
                }
            });

            app.MapGet("personinterests/{personID}", (int personID) =>
            {
                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                    var interests = APIFunctions.GetInterestsForPerson(context, personID);

                    var jsonOptions = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve
                    };

                    return Results.Json(interests, jsonOptions);
                }
            });

            app.MapGet("personinterestlinks/{personID}", (int personID) =>
            {
                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                    var interestLinks = APIFunctions.GetLinksForPerson(context, personID);

                    var person = context.People
                        .Where(p => p.PersonID == personID)
                        .Select(p => new { p.PersonID, p.Name })
                        .FirstOrDefault();

                    var response = new
                    {
                        PersonID = person?.PersonID,
                        Name = person?.Name,
                        InterestLinks = interestLinks
                    };

                    return Results.Json(response);
                }
            });

            app.MapPost("assigninterest/", (AssignInterestDto assingment) =>
            {
                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                    var result = APIFunctions.AssignInterest(context, assingment.PersonID, assingment.InterestID);

                    return result;
                }
            });

            app.MapPost("/createinterestlink", (CreateInterestLinkDto linkDto) =>
            {
                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                    return APIFunctions.CreateInterestLink(context, linkDto);
                }
            });

            app.Run();
        }
    }
}
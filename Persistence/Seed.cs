using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

//This method is used to fill the initial set of data to the database
namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DatabaseContext context)
        {
            context.Database.EnsureCreated();
            //Check if there are any users, if so return nothing
            if (!context.Users.Any())
            {
            //If there are no users in the DB, we create a static list of users
            var users = new List<User>
            {
                new() {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    Password = "password123",
                    Email = "john.doe@example.com",
                    Blogs = new List<Blog>
                    {
                        new() {
                            BlogId = Guid.NewGuid(),
                            Title = "First Blog",
                            Content = "This is the content of the first blog."
                        },
                        new() {
                            BlogId = Guid.NewGuid(),
                            Title = "Second Blog",
                            Content = "This is the content of the second blog."
                        }
                    }
                },
                new() {
                    Id = Guid.NewGuid(),
                    FirstName = "Jane",
                    LastName = "Doe",
                    Password = "password456",
                    Email = "jane.doe@example.com",
                    Blogs = new List<Blog>
                    {
                        new() {
                            BlogId = Guid.NewGuid(),
                            Title = "Third Blog",
                            Content = "This is the content of the third blog."
                        },
                        new() {
                            BlogId = Guid.NewGuid(),
                            Title = "Fourth Blog",
                            Content = "This is the content of the fourth blog."
                        }
                    }
                },
            };
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }            
        }
    }
}
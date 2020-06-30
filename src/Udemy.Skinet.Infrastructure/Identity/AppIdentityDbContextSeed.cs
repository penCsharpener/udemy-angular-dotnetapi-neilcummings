﻿using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities.Identity;

namespace Udemy.Skinet.Infrastructure.Identity {
    public class AppIdentityDbContextSeed {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager) {
            if (!userManager.Users.Any()) {
                var user = new AppUser {
                    DisplayName = "Bob",
                    Email = "bob@test.com",
                    UserName = "bob@test.com",
                    Address = new Address {
                        FirstName = "Bob",
                        LastName = "Bobbity",
                        Street = "10 The Street",
                        City = "New York",
                        State = "NY",
                        Zipcode = "90210"
                    }
                };

                var result = await userManager.CreateAsync(user, "Pa$$w0rd");

                if (!result.Succeeded) {
                    foreach (var error in result.Errors) {
                        System.Console.WriteLine($"{error.Code} {error.Description}");
                    }
                }
            }
        }
    }
}

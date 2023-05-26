using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Skinet.Core.Domain.Entities.Identity;

namespace Skinet.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager) 
        {
            if (!userManager.Users.Any()) 
            {
                var user = new AppUser() {
                    DisplayName = "Lipa",
                    Email = "lipa@test.com",
                    UserName = "lipa@test.com",
                    Address = new Address() {
                        FirstName = "Dua",
                        LastName = "Lipa",
                        Street = "10 Green Street",
                        City = "NewYork",
                        State = "NY",
                        ZipCode = "90210"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
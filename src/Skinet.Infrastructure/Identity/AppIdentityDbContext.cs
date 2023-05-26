using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Domain.Entities.Identity;

namespace Skinet.Infrastructure.Identity
{
  public class AppIdentityDbContext : IdentityDbContext<AppUser>
  {
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      this.SeedUsers(builder);
    }

    private void SeedUsers(ModelBuilder builder)
    {
      var user = new AppUser()
      {
        Id = "adbffd99-d818-4011-b5c4-fd444de139e6",
        DisplayName = "Lipa",
        Email = "lipa@test.com",
        NormalizedEmail = "LIPA@TEST.COM",
        UserName = "lipa@test.com",
        NormalizedUserName = "LIPA@TEST.COM"
      };
      
      var address = new Address()
      {
        Id = 1,
        FirstName = "Dua",
        LastName = "Lipa",
        Street = "10 Green Street",
        City = "NewYork",
        State = "NY",
        ZipCode = "90210",
        AppUserId = user.Id
      };

      PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
      user.PasswordHash = passwordHasher.HashPassword(user, "Pa$$w0rd");

      builder.Entity<AppUser>().HasData(user);
      builder.Entity<Address>().HasData(address);
    }
  }
}
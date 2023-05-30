using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skinet.Core.Domain.Entities.OrderAggregate;

namespace Skinet.Infrastructure.Data.Config
{
  public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
  {
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
      builder.OwnsOne(i => i.ItemOrdered, io =>
      {
        io.WithOwner();
      });

      builder.Property(i => i.Price)
          .HasColumnType("decimal(18, 2)");
    }
  }
}
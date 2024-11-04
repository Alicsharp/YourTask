using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.ToDoAgg;

namespace TodoList.Infrastructure.Persistent.Ef.TodoAgg
{
    internal class TodoConfiguration : IEntityTypeConfiguration<ItemList>
    {

        public void Configure(EntityTypeBuilder<ItemList> builder)
        {
            builder.OwnsMany(b => b.Items, option =>
            {
                option.ToTable("Items", "ItemList");
                option.HasKey(b => b.Id);

                option.Property(b => b.IsProcessed)
                    .IsRequired();
                    

                option.Property(b => b.Description)
                    .IsRequired()
                    .HasMaxLength(450);

                 
            });

        }
    }
}

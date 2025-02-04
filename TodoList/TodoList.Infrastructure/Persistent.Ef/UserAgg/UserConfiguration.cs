﻿using TodoList.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoList.Infrastructure.Persistent.Ef.UserAgg
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
 
            builder.HasIndex(b=>b.PhoneNumber).IsUnique();
            builder.HasIndex(b => b.Email).IsUnique();

            builder.Property(b => b.Email)
                .IsRequired(false)
                .HasMaxLength(256);

            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(b => b.Name)
                .IsRequired(false)

               .HasMaxLength(80);

            builder.Property(b => b.Family)
                .IsRequired(false)
                .HasMaxLength(80);

            builder.Property(b => b.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder.OwnsMany(b => b.Tokens, option =>
            {
                option.ToTable("Tokens", "user");
                option.HasKey(b => b.Id);

                option.Property(b => b.HashJwtToken)
                    .IsRequired()
                    .HasMaxLength(250);

                option.Property(b => b.HashRefreshToken)
                    .IsRequired()
                    .HasMaxLength(250);

                option.Property(b => b.Device)
                    .IsRequired()
                    .HasMaxLength(100);
            });

        }
    }
}

using System;
using DVP.Project.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVP.Project.Infrastructure.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasIndex(e => e.Username, "users_username_key")
            .IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");

            builder.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");

            builder.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        }
    }
}


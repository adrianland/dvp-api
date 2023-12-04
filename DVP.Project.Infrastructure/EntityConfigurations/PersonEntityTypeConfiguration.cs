using System;
using DVP.Project.Domain.AggregatesModel;
using DVP.Project.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DVP.Project.Infrastructure.EntityConfigurations
{
	public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("persons");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");

            builder.Property(e => e.DocumentNumber)
                .HasMaxLength(50)
                .HasColumnName("document_number");

            builder.Property(e => e.DocumentType)
                .HasMaxLength(50)
                .HasColumnName("document_type");

            builder.Property(e => e.Email)
                .HasMaxLength(50)
            .HasColumnName("email");

            builder.Property(e => e.FullDocument)
                .HasMaxLength(50)
                .HasColumnName("full_document");

            builder.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("full_name");

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
            .HasColumnName("name");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        }
    }
}


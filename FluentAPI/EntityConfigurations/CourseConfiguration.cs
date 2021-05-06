using FluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder
                .HasOne(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Cover)
                .WithOne(c => c.Course)
                .HasForeignKey<Cover>(c => c.CourseId);

            builder
                .HasMany(p => p.Tags)
                .WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                "CourseTag",
                 j => j
                    .HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("TagId"),
                j => j
                    .HasOne<Course>()
                    .WithMany()
                    .HasForeignKey("CourseId"));
        }
    }
}

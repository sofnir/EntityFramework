﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QueryingLINQ.Models;

namespace QueryingLINQ.Migrations
{
    [DbContext(typeof(PlutoContext))]
    [Migration("20210506115539_RenameCourseTagForeignKeys")]
    partial class RenameCourseTagForeignKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseTag", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("CourseTag");
                });

            modelBuilder.Entity("QueryingLINQ.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mosh hamedani"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Anthony Alicea"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Eric Wise"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tom Owsiak"
                        },
                        new
                        {
                            Id = 5,
                            Name = "John Smith"
                        });
                });

            modelBuilder.Entity("QueryingLINQ.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CoverId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<float>("FullPrice")
                        .HasColumnType("real");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CoverId = 0,
                            Description = "Description for C# Basics",
                            FullPrice = 49f,
                            Level = 1,
                            Name = "C# Basics"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            CoverId = 0,
                            Description = "Description for C# Intermediate",
                            FullPrice = 49f,
                            Level = 2,
                            Name = "C# Intermediate"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            CoverId = 0,
                            Description = "Description for C# Advanced",
                            FullPrice = 69f,
                            Level = 3,
                            Name = "C# Advanced"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            CoverId = 0,
                            Description = "Description for Javascript",
                            FullPrice = 149f,
                            Level = 2,
                            Name = "Javascript: Understanding the Weird Parts"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 2,
                            CoverId = 0,
                            Description = "Description for AngularJS",
                            FullPrice = 99f,
                            Level = 2,
                            Name = "Learn and Understand AngularJS"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 2,
                            CoverId = 0,
                            Description = "Description for NodeJS",
                            FullPrice = 149f,
                            Level = 2,
                            Name = "Learn and Understand NodeJS"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 3,
                            CoverId = 0,
                            Description = "Description for Programming for Beginners",
                            FullPrice = 45f,
                            Level = 1,
                            Name = "Programming for Complete Beginners"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 4,
                            CoverId = 0,
                            Description = "Description 16 Hour Course",
                            FullPrice = 150f,
                            Level = 1,
                            Name = "A 16 Hour C# Course with Visual Studio 2013"
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 4,
                            CoverId = 0,
                            Description = "Description Learn Javascript",
                            FullPrice = 20f,
                            Level = 1,
                            Name = "Learn JavaScript Through Visual Studio 2013"
                        });
                });

            modelBuilder.Entity("QueryingLINQ.Models.Cover", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("Cover");
                });

            modelBuilder.Entity("QueryingLINQ.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "c#"
                        },
                        new
                        {
                            Id = 2,
                            Name = "angularjs"
                        },
                        new
                        {
                            Id = 3,
                            Name = "javascript"
                        },
                        new
                        {
                            Id = 4,
                            Name = "nodejs"
                        },
                        new
                        {
                            Id = 5,
                            Name = "oop"
                        },
                        new
                        {
                            Id = 6,
                            Name = "linq"
                        });
                });

            modelBuilder.Entity("CourseTag", b =>
                {
                    b.HasOne("QueryingLINQ.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QueryingLINQ.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QueryingLINQ.Models.Course", b =>
                {
                    b.HasOne("QueryingLINQ.Models.Author", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("QueryingLINQ.Models.Cover", b =>
                {
                    b.HasOne("QueryingLINQ.Models.Course", "Course")
                        .WithOne("Cover")
                        .HasForeignKey("QueryingLINQ.Models.Cover", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("QueryingLINQ.Models.Author", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("QueryingLINQ.Models.Course", b =>
                {
                    b.Navigation("Cover");
                });
#pragma warning restore 612, 618
        }
    }
}

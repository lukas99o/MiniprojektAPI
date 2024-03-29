﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniprojektAPITakeTwo.Data;

#nullable disable

namespace MiniprojektAPITakeTwo.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240105202147_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.Property<int>("InterestsInterestID")
                        .HasColumnType("int");

                    b.Property<int>("PeoplePersonID")
                        .HasColumnType("int");

                    b.HasKey("InterestsInterestID", "PeoplePersonID");

                    b.HasIndex("PeoplePersonID");

                    b.ToTable("InterestPerson");
                });

            modelBuilder.Entity("MiniprojektAPITakeTwo.Models.Interest", b =>
                {
                    b.Property<int>("InterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestID");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("MiniprojektAPITakeTwo.Models.InterestLink", b =>
                {
                    b.Property<int>("InterestLinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestLinkID"), 1L, 1);

                    b.Property<int>("InterestID")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("InterestLinkID");

                    b.HasIndex("InterestID");

                    b.HasIndex("PersonID");

                    b.ToTable("InterestLinks");
                });

            modelBuilder.Entity("MiniprojektAPITakeTwo.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.HasOne("MiniprojektAPITakeTwo.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsInterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniprojektAPITakeTwo.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PeoplePersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniprojektAPITakeTwo.Models.InterestLink", b =>
                {
                    b.HasOne("MiniprojektAPITakeTwo.Models.Interest", null)
                        .WithMany("InterestLinks")
                        .HasForeignKey("InterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniprojektAPITakeTwo.Models.Person", null)
                        .WithMany("InterestLinks")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiniprojektAPITakeTwo.Models.Interest", b =>
                {
                    b.Navigation("InterestLinks");
                });

            modelBuilder.Entity("MiniprojektAPITakeTwo.Models.Person", b =>
                {
                    b.Navigation("InterestLinks");
                });
#pragma warning restore 612, 618
        }
    }
}

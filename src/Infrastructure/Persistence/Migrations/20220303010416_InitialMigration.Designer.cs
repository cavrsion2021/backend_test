﻿// <auto-generated />
using Anagrama.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Anagrama.Api.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220303010416_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Anagrama.Api.Domain.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstWord")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.Property<bool>("IsAnagram")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecondWord")
                        .IsRequired()
                        .HasColumnType("Varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
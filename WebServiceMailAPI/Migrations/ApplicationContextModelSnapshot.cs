﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebServiceMailAPI.Context;

#nullable disable

namespace WebServiceMailAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebServiceMailAPI.Models.Mail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Body");

                    b.Property<string>("FailedMessage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FailedMessage");

                    b.Property<string>("Recipients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Recipients");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Result");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Subject");

                    b.HasKey("Id");

                    b.ToTable("StoryMail");
                });
#pragma warning restore 612, 618
        }
    }
}
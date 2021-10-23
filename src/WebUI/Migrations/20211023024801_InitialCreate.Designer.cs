﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebUI.Data;

namespace WebUI.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20211023024801_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("WebUI.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Synopsis")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("YearPublished")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Miguel de Cervantes Saavedra",
                            Synopsis = "The ingenious gentleman Don Quixote of La Mancha",
                            Title = "Don Quixote - Part 1",
                            YearPublished = 1605
                        },
                        new
                        {
                            Id = 2,
                            Author = "Miguel de Cervantes Saavedra",
                            Synopsis = "The ingenious gentleman Don Quixote of La Mancha",
                            Title = "Don Quixote - Part 1",
                            YearPublished = 1615
                        });
                });

            modelBuilder.Entity("WebUI.Data.BookMedium", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediumId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookId", "MediumId");

                    b.HasIndex("MediumId");

                    b.ToTable("BookMedium");
                });

            modelBuilder.Entity("WebUI.Data.Medium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Media");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Book"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Audiobook"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Ebook"
                        });
                });

            modelBuilder.Entity("WebUI.Data.BookMedium", b =>
                {
                    b.HasOne("WebUI.Data.Book", "Book")
                        .WithMany("AvailableMedia")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebUI.Data.Medium", "Medium")
                        .WithMany()
                        .HasForeignKey("MediumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Medium");
                });

            modelBuilder.Entity("WebUI.Data.Book", b =>
                {
                    b.Navigation("AvailableMedia");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PowellApi.Models;

#nullable disable

namespace PowellApi.Migrations
{
    [DbContext(typeof(PowellApiContext))]
    partial class PowellApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PowellApi.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("longtext");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "Fred Jumpturd",
                            Summary = "Summary1Summary1Summary1Summary1Summary1Summary1",
                            Title = "Linux For Dummies"
                        },
                        new
                        {
                            BookId = 2,
                            Summary = "Summary2Summary2Summary2Summary2Summary2",
                            Title = "Api for Dummies"
                        },
                        new
                        {
                            BookId = 3,
                            Summary = "Summary3Summary3Summary3Summary3Summary3",
                            Title = "C# for Dummies"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

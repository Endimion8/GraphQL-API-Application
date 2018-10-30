﻿// <auto-generated />
using System;
using GraphQLAPI.Library.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Library.Dal.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GraphQLAPI.Library.Dal.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("Name");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("GraphQLAPI.Library.Dal.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Dal.Models.AuthorBook", b =>
                {
                    b.Property<int>("AuthorAuthorId");

                    b.Property<int>("BookBookId");

                    b.Property<bool>("IsAuthor");

                    b.HasKey("AuthorAuthorId", "BookBookId");

                    b.HasIndex("BookBookId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("Library.Dal.Models.AuthorBook", b =>
                {
                    b.HasOne("GraphQLAPI.Library.Dal.Models.Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorAuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GraphQLAPI.Library.Dal.Models.Book")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("BookBookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

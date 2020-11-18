﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using News_WebApp.Models;

namespace News_WebApp.Migrations
{
    [DbContext(typeof(NewsDbContext))]
    [Migration("20200310130018_initial_update")]
    partial class initial_update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("News_WebApp.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlToImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NewsId");

                    b.HasIndex("UserId");

                    b.ToTable("NewsList");
                });

            modelBuilder.Entity("News_WebApp.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = "Jack",
                            Password = "password@123"
                        },
                        new
                        {
                            UserId = "John",
                            Password = "password@123"
                        });
                });

            modelBuilder.Entity("News_WebApp.Models.News", b =>
                {
                    b.HasOne("News_WebApp.Models.User", "User")
                        .WithMany("NewsList")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}

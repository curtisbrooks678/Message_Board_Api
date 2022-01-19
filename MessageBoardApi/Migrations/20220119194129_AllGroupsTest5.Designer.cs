﻿// <auto-generated />
using System;
using MessageBoardApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageBoardApi.Migrations
{
    [DbContext(typeof(MessageBoardApiContext))]
    [Migration("20220119194129_AllGroupsTest5")]
    partial class AllGroupsTest5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MessageBoardApi.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            GroupName = "Group1! We did it! Amazing work!"
                        });
                });

            modelBuilder.Entity("MessageBoardApi.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4");

                    b.HasKey("MessageId");

                    b.HasIndex("GroupId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            Content = "content1",
                            DatePosted = new DateTime(2022, 1, 18, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            UserName = "user1"
                        },
                        new
                        {
                            MessageId = 2,
                            Content = "content2",
                            DatePosted = new DateTime(2021, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            UserName = "user2"
                        },
                        new
                        {
                            MessageId = 3,
                            Content = "content3",
                            DatePosted = new DateTime(2020, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            UserName = "user3"
                        },
                        new
                        {
                            MessageId = 4,
                            Content = "content3",
                            DatePosted = new DateTime(2020, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            UserName = "user3"
                        },
                        new
                        {
                            MessageId = 5,
                            Content = "content3",
                            DatePosted = new DateTime(2020, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            UserName = "user3"
                        },
                        new
                        {
                            MessageId = 6,
                            Content = "content3",
                            DatePosted = new DateTime(2020, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            UserName = "user3"
                        });
                });

            modelBuilder.Entity("MessageBoardApi.Models.Message", b =>
                {
                    b.HasOne("MessageBoardApi.Models.Group", "Group")
                        .WithMany("Messages")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("MessageBoardApi.Models.Group", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}

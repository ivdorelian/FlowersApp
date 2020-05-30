﻿// <auto-generated />
using System;
using FlowersApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlowersApp.Migrations
{
    [DbContext(typeof(FlowersDbContext))]
    [Migration("20200530091347_AddUserAndLinksWithOtherEntities")]
    partial class AddUserAndLinksWithOtherEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlowersApp.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddedById")
                        .HasColumnType("bigint");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("FlowerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("FlowerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FlowersApp.Models.Flower", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddedById")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlowerUpkeepDifficulty")
                        .HasColumnType("int");

                    b.Property<long>("MarketPrice")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.ToTable("Flowers");
                });

            modelBuilder.Entity("FlowersApp.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlowersApp.Models.Comment", b =>
                {
                    b.HasOne("FlowersApp.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("FlowersApp.Models.Flower", "Flower")
                        .WithMany("Comments")
                        .HasForeignKey("FlowerId");
                });

            modelBuilder.Entity("FlowersApp.Models.Flower", b =>
                {
                    b.HasOne("FlowersApp.Models.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");
                });
#pragma warning restore 612, 618
        }
    }
}

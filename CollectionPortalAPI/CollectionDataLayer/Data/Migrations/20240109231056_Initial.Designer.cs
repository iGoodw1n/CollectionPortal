﻿// <auto-generated />
using System;
using CollectionDataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CollectionDataLayer.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240109231056_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CollectionDataLayer.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CollectionDataLayer.Entities.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("CustomCheckBox1Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomCheckBox1State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomCheckBox2Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomCheckBox2State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomCheckBox3Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomCheckBox3State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomDate1Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomDate1State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomDate2Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomDate2State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomDate3Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomDate3State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomInt1Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomInt1State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomInt2Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomInt2State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomInt3Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomInt3State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomString1Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomString1State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomString2Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomString2State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomString3Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomString3State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomText1Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomText1State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomText2Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomText2State")
                        .HasColumnType("boolean");

                    b.Property<string>("CustomText3Name")
                        .HasColumnType("text");

                    b.Property<bool>("CustomText3State")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("CollectionDataLayer.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("CustomCheckBox1")
                        .HasColumnType("boolean");

                    b.Property<bool?>("CustomCheckBox2")
                        .HasColumnType("boolean");

                    b.Property<bool?>("CustomCheckBox3")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("CustomDate1")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("CustomDate2")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("CustomDate3")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CustomInt1")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomInt2")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomInt3")
                        .HasColumnType("integer");

                    b.Property<string>("CustomString1")
                        .HasColumnType("text");

                    b.Property<string>("CustomString2")
                        .HasColumnType("text");

                    b.Property<string>("CustomString3")
                        .HasColumnType("text");

                    b.Property<string>("CustomText1")
                        .HasColumnType("text");

                    b.Property<string>("CustomText2")
                        .HasColumnType("text");

                    b.Property<string>("CustomText3")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CollectionDataLayer.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CollectionDataLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CollectionDataLayer.Entities.Collection", b =>
                {
                    b.HasOne("CollectionDataLayer.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollectionDataLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CollectionDataLayer.Entities.Tag", b =>
                {
                    b.HasOne("CollectionDataLayer.Entities.Item", null)
                        .WithMany("Tags")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("CollectionDataLayer.Entities.Item", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
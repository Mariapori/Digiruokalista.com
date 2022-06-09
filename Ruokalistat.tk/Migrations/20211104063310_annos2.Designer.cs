﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ruokalistat.tk.Models;

namespace Ruokalistat.tk.Migrations
{
    [DbContext(typeof(tietokantaContext))]
    [Migration("20211104063310_annos2")]
    partial class annos2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique();

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetRoleClaim", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("EmailConfirmed")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<byte[]>("LockoutEnabled")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<byte[]>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar");

                    b.Property<byte[]>("PhoneNumberConfirmed")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar");

                    b.Property<byte[]>("TwoFactorEnabled")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique();

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetUserClaim", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Kategoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kuvaus")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nimi")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RuokalistaID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("RuokalistaID");

                    b.ToTable("Kategoria");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Ruoka", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Annos")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Hinta")
                        .HasColumnType("TEXT");

                    b.Property<int?>("KategoriaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kuvaus")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nimi")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Vegan")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("KategoriaID");

                    b.ToTable("Ruoka");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Ruokalista", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("piilotettu")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("viimeksiPaivitetty")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Ruokalista");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Yritys", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kaupunki")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nimi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Osoite")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Postinumero")
                        .HasColumnType("TEXT");

                    b.Property<string>("Puhelin")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RuokalistaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("yTunnus")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RuokalistaID");

                    b.ToTable("Yritys");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetRoleClaim", b =>
                {
                    b.HasOne("Ruokalistat.tk.Models.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetUserClaim", b =>
                {
                    b.HasOne("Ruokalistat.tk.Models.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetUserLogin", b =>
                {
                    b.HasOne("Ruokalistat.tk.Models.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetUserRole", b =>
                {
                    b.HasOne("Ruokalistat.tk.Models.AspNetRole", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ruokalistat.tk.Models.AspNetUser", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetUserToken", b =>
                {
                    b.HasOne("Ruokalistat.tk.Models.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Kategoria", b =>
                {
                    b.HasOne("Ruokalistat.tk.Models.Ruokalista", null)
                        .WithMany("Kategoriat")
                        .HasForeignKey("RuokalistaID");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Ruoka", b =>
                {
                    b.HasOne("Ruokalistat.tk.Models.Kategoria", null)
                        .WithMany("Ruuat")
                        .HasForeignKey("KategoriaID");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Yritys", b =>
                {
                    b.HasOne("Ruokalistat.tk.Models.AspNetUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("Ruokalistat.tk.Models.Ruokalista", "Ruokalista")
                        .WithMany()
                        .HasForeignKey("RuokalistaID");

                    b.Navigation("Owner");

                    b.Navigation("Ruokalista");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");

                    b.Navigation("AspNetUserRoles");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.AspNetUser", b =>
                {
                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserRoles");

                    b.Navigation("AspNetUserTokens");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Kategoria", b =>
                {
                    b.Navigation("Ruuat");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Ruokalista", b =>
                {
                    b.Navigation("Kategoriat");
                });
#pragma warning restore 612, 618
        }
    }
}

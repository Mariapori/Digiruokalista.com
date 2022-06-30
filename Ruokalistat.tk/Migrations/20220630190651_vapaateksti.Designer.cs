﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ruokalistat.tk.Models;

#nullable disable

namespace Digiruokalista.com.Migrations
{
    [DbContext(typeof(tietokantaContext))]
    [Migration("20220630190651_vapaateksti")]
    partial class vapaateksti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Digiruokalista.com.Models.Hintahistoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Hinta")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PVM")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RuokaID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("RuokaID");

                    b.ToTable("Hintahistoria");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Arvostelu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("source")
                        .HasColumnType("TEXT");

                    b.Property<int?>("yritysID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("yritysID");

                    b.ToTable("Arvostelu");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Kategoria", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kuvaus")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nimi")
                        .IsRequired()
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

                    b.Property<int>("AnnosNumero")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Hinta")
                        .HasColumnType("TEXT");

                    b.Property<int?>("KategoriaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kuvaus")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nimi")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nimi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Osoite")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Owner")
                        .HasColumnType("TEXT");

                    b.Property<string>("Postinumero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Puhelin")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RuokalistaID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VapaaTeksti")
                        .HasColumnType("TEXT");

                    b.Property<string>("yTunnus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("RuokalistaID");

                    b.ToTable("Yritys");
                });

            modelBuilder.Entity("Digiruokalista.com.Models.Hintahistoria", b =>
                {
                    b.HasOne("Ruokalistat.tk.Models.Ruoka", "Ruoka")
                        .WithMany()
                        .HasForeignKey("RuokaID");

                    b.Navigation("Ruoka");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Arvostelu", b =>
                {
                    b.HasOne("Ruokalistat.tk.Models.Yritys", "yritys")
                        .WithMany("Arvostelut")
                        .HasForeignKey("yritysID");

                    b.Navigation("yritys");
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
                    b.HasOne("Ruokalistat.tk.Models.Ruokalista", "Ruokalista")
                        .WithMany()
                        .HasForeignKey("RuokalistaID");

                    b.Navigation("Ruokalista");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Kategoria", b =>
                {
                    b.Navigation("Ruuat");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Ruokalista", b =>
                {
                    b.Navigation("Kategoriat");
                });

            modelBuilder.Entity("Ruokalistat.tk.Models.Yritys", b =>
                {
                    b.Navigation("Arvostelut");
                });
#pragma warning restore 612, 618
        }
    }
}

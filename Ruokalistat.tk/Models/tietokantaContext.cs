using System;
using Digiruokalista.com.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ruokalistat.tk.Models
{
    public partial class tietokantaContext : DbContext
    {
        public tietokantaContext()
        {
            Database.Migrate();
        }

        public tietokantaContext(DbContextOptions<tietokantaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Yritys> Yritys { get; set; }
        public virtual DbSet<Hintahistoria> Hintahistoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=tietokanta.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("nvarchar(450)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("nvarchar");

                entity.Property(e => e.Name).HasColumnType("nvarchar(256)");

                entity.Property(e => e.NormalizedName).HasColumnType("nvarchar(256)");
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id)
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClaimType).HasColumnType("nvarchar");

                entity.Property(e => e.ClaimValue).HasColumnType("nvarchar");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("nvarchar(450)");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("nvarchar");

                entity.Property(e => e.Email).HasColumnType("nvarchar(256)");

                entity.Property(e => e.EmailConfirmed)
                    .IsRequired()
                    .HasColumnType("bit");

                entity.Property(e => e.LockoutEnabled)
                    .IsRequired()
                    .HasColumnType("bit");

                entity.Property(e => e.LockoutEnd).HasColumnType("datetimeoffset");

                entity.Property(e => e.NormalizedEmail).HasColumnType("nvarchar(256)");

                entity.Property(e => e.NormalizedUserName).HasColumnType("nvarchar(256)");

                entity.Property(e => e.PasswordHash).HasColumnType("nvarchar");

                entity.Property(e => e.PhoneNumber).HasColumnType("nvarchar");

                entity.Property(e => e.PhoneNumberConfirmed)
                    .IsRequired()
                    .HasColumnType("bit");

                entity.Property(e => e.SecurityStamp).HasColumnType("nvarchar");

                entity.Property(e => e.TwoFactorEnabled)
                    .IsRequired()
                    .HasColumnType("bit");

                entity.Property(e => e.UserName).HasColumnType("nvarchar(256)");
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id)
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClaimType).HasColumnType("nvarchar");

                entity.Property(e => e.ClaimValue).HasColumnType("nvarchar");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasColumnType("nvarchar(128)");

                entity.Property(e => e.ProviderKey).HasColumnType("nvarchar(128)");

                entity.Property(e => e.ProviderDisplayName).HasColumnType("nvarchar");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId).HasColumnType("nvarchar(450)");

                entity.Property(e => e.RoleId).HasColumnType("nvarchar(450)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.UserId).HasColumnType("nvarchar(450)");

                entity.Property(e => e.LoginProvider).HasColumnType("nvarchar(128)");

                entity.Property(e => e.Name).HasColumnType("nvarchar(128)");

                entity.Property(e => e.Value).HasColumnType("nvarchar");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

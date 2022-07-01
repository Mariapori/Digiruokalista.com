using System;
using Digiruokalista.com.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

#nullable disable

namespace Ruokalistat.tk.Models
{
    public partial class tietokantaContext : IdentityDbContext
    {
        private readonly ILogger _logger;
        public tietokantaContext()
        {
            
        }

        public tietokantaContext(DbContextOptions<tietokantaContext> options,ILogger<tietokantaContext> logger)
            : base(options)
        {

            _logger = logger;
            try 
            {
                Database.Migrate();
                _logger.LogInformation("Tietokanta migraatio on suoritettu!");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"Tietokanta migraatiota ei voitu toteuttaa.");
            }
        }

        public virtual DbSet<Yritys> Yritys { get; set; }
        public virtual DbSet<Hintahistoria> Hintahistoria { get; set; }
        public virtual DbSet<Ruokalista> Ruokalista {get;set;}
        public virtual DbSet<Ruoka> Ruoka {get;set;}
        public virtual DbSet<Kategoria> Kategoria {get;set;}
        public virtual DbSet<Arvostelu> Arvostelu {get;set;}
        

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
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

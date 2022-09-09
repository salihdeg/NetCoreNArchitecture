using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        public IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingTechnology> programmingTechnologies { get; set; }
        public DbSet<ProgrammingTechnologyType> ProgrammingTechnologyTypes { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
                p.HasMany(p => p.ProgrammingTechnologies);
            });

            modelBuilder.Entity<ProgrammingTechnologyType>(p =>
            {
                p.ToTable("ProgrammingTechnologyTypes").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
                p.HasMany(p => p.ProgrammingTechnologies);
            });

            modelBuilder.Entity<ProgrammingTechnology>(p =>
            {
                p.ToTable("ProgrammingTechnologies").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                p.Property(p => p.ProgrammingTechnologyTypeId).HasColumnName("ProgrammingTechnologyTypeId");
                p.Property(p => p.Name).HasColumnName("Name");
                p.HasOne(p => p.ProgrammingLanguage);
                p.HasOne(p => p.ProgrammingTechnologyType);
            });

            ProgrammingLanguage[] programmingLanguageSeedData = { new(1, "c#"), new(2, "Java"), new(3, "Rust") };
            ProgrammingTechnologyType[] programmingTechnologyTypeSeedData = { new(1, "Framework"), new(2, "Library") };
            ProgrammingTechnology[] programmingTechnologies = { new(1, 1, 1, "ASP.NET"), new(2, 2, 2, "Google Guava"), new(3, 3, 1, "GGEZ") };

            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeedData);
            modelBuilder.Entity<ProgrammingTechnologyType>().HasData(programmingTechnologyTypeSeedData);
            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologies);
        }
    }
}

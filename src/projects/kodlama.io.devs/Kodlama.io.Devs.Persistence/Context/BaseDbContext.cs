using Core.Security.Entities;
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
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<SocialPlatform> SocialPlatforms { get; set; }
        public DbSet<UserProfileSocialAccount> UserProfileSocialAccounts { get; set; }

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

            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Email).HasColumnName("Email");
                p.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                p.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(p => p.Status).HasColumnName("Status");
                p.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                p.HasMany(p => p.RefreshTokens);
                p.HasMany(p => p.UserOperationClaims);
            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.HasOne(p => p.User);
                p.HasOne(p => p.OperationClaim);
            });

            modelBuilder.Entity<UserProfile>(p =>
            {
                p.ToTable("UserProfiles");
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.FirstName).HasColumnName("FirstName");
                p.Property(p => p.LastName).HasColumnName("LastName");
                p.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth");
                p.Property(p => p.AccountCreateTime).HasColumnName("AccountCreateTime");
                p.Property(p => p.LastLogin).HasColumnName("LastLogin");
                p.HasMany(p => p.UserProfileSocialAccounts);
            });

            modelBuilder.Entity<SocialPlatform>(p =>
            {
                p.ToTable("SocialPlatforms").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
                p.Property(p => p.DomainAddress).HasColumnName("DomainAddress");
                p.HasMany(p => p.UserProfileSocialAccounts);
            });

            modelBuilder.Entity<UserProfileSocialAccount>(p =>
            {
                p.ToTable("UserProfileSocialAccounts").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.SocialPlatformId).HasColumnName("SocialPlatformId");
                p.Property(p => p.SocialPlatformURI).HasColumnName("SocialPlatformURI");
                p.HasOne(p => p.SocialPlatform);
                p.HasOne(p => p.UserProfile);
            });

            ProgrammingLanguage[] programmingLanguageSeedData = { new(1, "c#"), new(2, "Java"), new(3, "Rust") };
            ProgrammingTechnologyType[] programmingTechnologyTypeSeedData = { new(1, "Framework"), new(2, "Library") };
            ProgrammingTechnology[] programmingTechnologies = { new(1, 1, 1, "ASP.NET"), new(2, 2, 2, "Google Guava"), new(3, 3, 1, "GGEZ") };
            SocialPlatform[] socialPlatformSeedData = { new(1, "Github", "https://github.com/") };
            OperationClaim[] operationClaimSeedData = { new(1, "Admin"), new(2, "User") };

            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeedData);
            modelBuilder.Entity<ProgrammingTechnologyType>().HasData(programmingTechnologyTypeSeedData);
            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologies);
            modelBuilder.Entity<SocialPlatform>().HasData(socialPlatformSeedData);
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimSeedData);
        }
    }
}

using IntelAssessmentAPI.Models.Profile;
using IntelAssessmentAPI.Models.Detail;
using IntelAssessmentAPI.Models.JobHistory;
using IntelAssessmentAPI.Models.Education;
using IntelAssessmentAPI.Models.Biography;
using IntelAssessmentAPI.Models.SocMed;
using Microsoft.EntityFrameworkCore;
using IntelAssessmentAPI.Models.Image;

namespace IntelAssessmentAPI.Data
{
    public class AboutAPIDbContext : DbContext
    {
        public AboutAPIDbContext(DbContextOptions options) : base(options) {}
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Detail> Detail { get; set; }
        public DbSet<JobHistory> JobHistory { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Biography> Biography { get; set; }
        public DbSet<SocMed> SocMed { get; set; }
        public DbSet<Image> Image { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.Detail)
                .WithOne(p => p.Profile)
                .HasForeignKey<Detail>(p => p.IdProfile)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.JobHistory)
                .WithOne(p => p.Profile)
                .HasForeignKey(p => p.IdProfile)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Education)
                .WithOne(p => p.Profile)
                .HasForeignKey(p => p.IdProfile)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Biography)
                .WithOne(p => p.Profile)
                .HasForeignKey(p => p.IdProfile)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.SocMed)
                .WithOne(p => p.Profile)
                .HasForeignKey(p => p.IdProfile)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Image)
                .WithOne(p => p.Profile)
                .HasForeignKey(p => p.IdProfile)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Detail>()
                .HasIndex(p => p.IdProfile)
                .IsUnique();

            //modelBuilder.Entity<Detail>()
            //    .Property(d => d.Hobby)
            //    .HasColumnName("Hobby")
            //    .HasColumnType("string[]")
            //    .HasConversion(
            //        v => string.Join(",", v ?? Array.Empty<string>()),
            //        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
            //    );

            //modelBuilder.Entity<Detail>()
            //    .Property(d => d.Skill)
            //    .HasColumnName("Skill")
            //    .HasColumnType("string[]")
            //    .HasConversion(
            //        v => string.Join(",", v ?? Array.Empty<string>()),
            //        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
            //    );

            //modelBuilder.Entity<Detail>()
            //    .Property(d => d.Pet)
            //    .HasColumnName("Pet")
            //    .HasColumnType("string[]")
            //    .HasConversion(
            //        v => string.Join(",", v ?? Array.Empty<string>()),
            //        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
            //    );

            //modelBuilder.Entity<Detail>()
            //    .Property(d => d.FreeTimeActivity)
            //    .HasColumnName("FreeTimeActivity")
            //    .HasColumnType("string[]")
            //    .HasConversion(
            //        v => string.Join(",", v ?? Array.Empty<string>()),
            //        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
            //    );

           //modelBuilder.Entity<Detail>()
           //     .Property(d => d.Interest)
           //     .HasColumnName("Interest")
           //     .HasColumnType("string[]")
           //     .HasConversion(
           //         v => string.Join(",", v ?? Array.Empty<string>()),
           //         v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
           //     );

            //modelBuilder.Entity<Detail>()
            //    .Property(d => d.FavouriteFood)
            //    .HasColumnName("FavouriteFood")
            //    .HasColumnType("string[]")
            //    .HasConversion(
            //        v => string.Join(",", v ?? Array.Empty<string>()),
            //        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
            //    );


        }
    }
}

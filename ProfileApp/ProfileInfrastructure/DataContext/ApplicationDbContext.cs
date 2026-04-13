using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProfileDomain.Interfaces;
using ProfileDomain.Models;
namespace ProfileInfrastructure.DataContext;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public async Task<int> SaveChangesAsync(Guid userObjectId)
    {
        return await SaveChanges(userObjectId);
    }
    public async Task<int> SaveChanges(Guid userObjectId)
    {
        var selectedEntityList = ChangeTracker.Entries().
            Where(x => x.Entity is BaseEntity && (x.State == EntityState.Modified || x.State == EntityState.Added));


        foreach (var entity in selectedEntityList)
        {
            ((BaseEntity)entity.Entity).ModifiedBy = userObjectId;
            ((BaseEntity)entity.Entity).Modified = DateTime.Now.ToUniversalTime();

            if (entity.State == EntityState.Added)
                ((BaseEntity)entity.Entity).Id = Guid.NewGuid();
        }

        return await base.SaveChangesAsync();
    }

    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SocialLink> SocialLinks { get; set; }
    public DbSet<Certification> Certifications { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // builder.Entity<ApplicationUser>()
        //     .HasOne(a => a.Profile)
        //     .WithOne()
        //     .HasForeignKey<Profile>(p => p.UserId)
        //     .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Profile>()
            .HasOne<ApplicationUser>()
            .WithOne()
            .HasForeignKey<Profile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Education>()
            .HasOne(p => p.Profile)
            .WithMany(e => e.Educations)
            .HasForeignKey(s => s.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<Skill>()
            .HasOne(p => p.Profile)
            .WithMany(e => e.Skills)
            .HasForeignKey(s => s.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Project>()
            .HasOne(p => p.Profile)
            .WithMany(e => e.Projects)
            .HasForeignKey(s => s.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Experience>()
            .HasOne(p => p.Profile)
            .WithMany(e => e.Experiences)
            .HasForeignKey(s => s.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<SocialLink>()
            .HasOne(p => p.Profile)
            .WithMany(e => e.SocialLinks)
            .HasForeignKey(s => s.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Certification>()
            .HasOne(p => p.Profile)
            .WithMany(e => e.Certifications)
            .HasForeignKey(s => s.ProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

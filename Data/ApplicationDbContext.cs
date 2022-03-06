using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetAtlas.Models;

namespace NetAtlas.Data
{
    public class ApplicationDbContext : IdentityDbContext<NetAtlasUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<NetAtlasUser>(b =>
        {
            // Each User can have many UserClaims
            b.HasMany(e => e.ListeDemandes)
                .WithOne()
                .HasForeignKey(ut => ut.Amis1ID)
                .IsRequired();
        });
            builder.Entity<NetAtlasUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.ListeDemandes)
                    .WithOne()
                    .HasForeignKey(uc=> uc.Amis2ID)
                    .IsRequired();
            });
            builder.Entity<NetAtlasUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Publications)
                    .WithOne()
                    .HasForeignKey(ul => ul.MembreID)
                    .IsRequired();
            });
           
        }
        public DbSet<NetAtlas.Models.DemandeDAmis> DemandeDAmis { get; set; }
        public DbSet<NetAtlas.Models.Publication> Publication { get; set; }
        public DbSet<NetAtlas.Models.Ressource> Ressource { get; set; }
        public DbSet<NetAtlas.Models.RessourceLien> RessourceLien { get; set; }
        public DbSet<NetAtlas.Models.RessourceMessage> RessourceMessage { get; set; }
        public DbSet<NetAtlas.Models.RessourcePhotoVideo> RessourcePhotoVideo { get; set; }
        public DbSet<NetAtlas.Models.NetAtlasUser> NetAtlasUser { get; set; }



    }
}
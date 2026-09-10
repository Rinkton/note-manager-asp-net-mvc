using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NoteModel> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteModel>()
                .ToTable("Notes")
                .HasKey(n => n.Id);

            modelBuilder.Entity<NoteModel>()
                .Property(n => n.Text)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}

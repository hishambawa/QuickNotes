using Microsoft.EntityFrameworkCore;

namespace QuickNotes.Models
{
    public class NotesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=157.230.241.112;user=hisham;password=pokerface0958;database=quick_notes", ServerVersion.Parse("8.0.29-mysql"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.NoteId);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Content).IsRequired();
                entity.HasOne(d => d.User)
                  .WithMany(p => p.Notes);
            });
        }
    }
}


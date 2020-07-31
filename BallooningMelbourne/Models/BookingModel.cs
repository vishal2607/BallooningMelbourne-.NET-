namespace BallooningMelbourne.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookingModel : DbContext
    {
        public BookingModel()
            : base("name=BookingModel")
        {
        }

        public virtual DbSet<AdminEventtable> AdminEventtables { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<booking> bookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEventtable>()
                .HasMany(e => e.bookings)
                .WithRequired(e => e.AdminEventtable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AdminEventtables)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.bookings)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<BallooningMelbourne.Models.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<BallooningMelbourne.Models.Comment> Comments { get; set; }
    }
}

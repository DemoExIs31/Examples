using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfApp2.Entities
{
    public partial class EntityContext : DbContext
    {
        public EntityContext()
            : base("name=EntityContext")
        {
        }

        public virtual DbSet<AnimalData> AnimalData { get; set; }
        public virtual DbSet<AnimalsInAvairy> AnimalsInAvairy { get; set; }
        public virtual DbSet<Aviary> Aviary { get; set; }
        public virtual DbSet<Feed> Feed { get; set; }
        public virtual DbSet<FeedOfAnimal> FeedOfAnimal { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<ResponsibleForAnimals> ResponsibleForAnimals { get; set; }
        public virtual DbSet<SalarOfEmployee> SalarOfEmployee { get; set; }
        public virtual DbSet<SalaryCoeffiecient> SalaryCoeffiecient { get; set; }
        public virtual DbSet<StoredOfFeed> StoredOfFeed { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }
        public virtual DbSet<WorkShiftSchedule> WorkShiftSchedule { get; set; }
        public virtual DbSet<UsersWithPosition> UsersWithPosition { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalData>()
                .HasMany(e => e.AnimalsInAvairy)
                .WithRequired(e => e.AnimalData)
                .HasForeignKey(e => e.AnimalId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AnimalData>()
                .HasMany(e => e.FeedOfAnimal)
                .WithRequired(e => e.AnimalData)
                .HasForeignKey(e => e.AnimalId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AnimalData>()
                .HasMany(e => e.ResponsibleForAnimals)
                .WithRequired(e => e.AnimalData)
                .HasForeignKey(e => e.AnimalId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Aviary>()
                .HasMany(e => e.AnimalsInAvairy)
                .WithRequired(e => e.Aviary)
                .HasForeignKey(e => e.AvairyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feed>()
                .HasMany(e => e.FeedOfAnimal)
                .WithRequired(e => e.Feed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalaryCoeffiecient>()
                .Property(e => e.MinSalaryValue)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SalaryCoeffiecient>()
                .Property(e => e.Coeff)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SalaryCoeffiecient>()
                .HasMany(e => e.SalarOfEmployee)
                .WithRequired(e => e.SalaryCoeffiecient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserData>()
                .HasMany(e => e.ResponsibleForAnimals)
                .WithRequired(e => e.UserData)
                .HasForeignKey(e => e.ResponsibleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserData>()
                .HasMany(e => e.SalarOfEmployee)
                .WithRequired(e => e.UserData)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkShiftSchedule>()
                .HasMany(e => e.SalarOfEmployee)
                .WithRequired(e => e.WorkShiftSchedule)
                .WillCascadeOnDelete(false);
        }
    }
}

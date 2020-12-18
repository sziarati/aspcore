using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Session08.Audit.Entities;
using System;
using System.Linq;
using System.Reflection;

namespace Session08.Audit.EFDAL
{
    public class TeacherContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;initial catalog=Session08.dbaudit;integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }
        public override int SaveChanges()
        {
            var Entries1 = ChangeTracker.Entries().Where(c => typeof(IAuditable).IsAssignableFrom(c.Entity.GetType()));
            var Entries2 = ChangeTracker.Entries().Where(c => typeof(IAuditable02).IsAssignableFrom(c.Entity.GetType()));
            foreach (var item in Entries1)
            {
                var temp = item.Entity as IAuditable;
                if(item.State==EntityState.Added)
                {
                    temp.InsertBy = 1;
                    temp.InsertDate = DateTime.Now;
                }
                if(item.State == EntityState.Modified)
                {
                    temp.UPdateBy = 1;
                    temp.UpdateDate = DateTime.Now;
                }
            }
            foreach (var item in Entries2)
            {
                var temp = item.Entity as IAuditable02;
                if(item.State==EntityState.Added)
                {
                    item.Entity.
                }
                if(item.State == EntityState.Modified)
                {
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypes = modelBuilder.Model.GetEntityTypes().Where(c => typeof(IAuditable02).IsAssignableFrom(c.ClrType));
            foreach (var item in entityTypes)
            {
                modelBuilder.Entity(item.ClrType).Property<int>("InsertBy");
                modelBuilder.Entity(item.ClrType).Property<int>("UpdateBy");
                modelBuilder.Entity(item.ClrType).Property<DateTime>("InsertDate");
                modelBuilder.Entity(item.ClrType).Property<DateTime>("UpdateDate");
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}

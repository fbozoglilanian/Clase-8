using Tresana.Data.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Tresana.Data.DataAccess
{
    public class TresanaContext : DbContext
    {
        public TresanaContext() : base("name=TresanaContext") { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Task>()
                .HasMany<User>(task => task.ResponsibleUsers)
                .WithMany(user => user.Tasks)
                .Map(mc =>
                {
                    mc.ToTable("UsersTasks");
                    mc.MapLeftKey("Task");
                    mc.MapRightKey("User");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}

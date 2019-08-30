using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Users
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection") { } // Подключение к базе данных
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Zakazi>().ToTable("Zakazi"); // Название таблицы
        }
        public DbSet<Zakazi> Zakaz { get; set; } // Модель базы данных
    }
}
    
using Microsoft.EntityFrameworkCore;
using System;

namespace FastSchool.Model
{
    /// <summary>
    /// EF数据上下文
    /// </summary>
    public class FastSchoolDBContext : DbContext
    {
        public FastSchoolDBContext()
        {

        }

        public FastSchoolDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Commodity> Commodity { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseMySql("server=localhost;port=3306;database=FastSchoolDB;uid=root;pwd=123456;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //配置全局查询过滤
            modelBuilder.Entity<User>(u =>
            u.HasQueryFilter(n =>
            n.IsDelete.Equals(false)));

            modelBuilder.Entity<Commodity>(u =>
           u.HasQueryFilter(n =>
           n.IsDelete.Equals(false) && n.State.Equals(false)));

            modelBuilder.Entity<Order>(u =>
           u.HasQueryFilter(n =>
           n.IsDelete.Equals(false)));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Xelat.Project.Authorization.Roles;
using Xelat.Project.Authorization.Users;
using Xelat.Project.Customers;
using Xelat.Project.MultiTenancy;
using Xelat.Project.Products;

namespace Xelat.Project.EntityFrameworkCore
{
    public class ProjectDbContext : AbpZeroDbContext<Tenant, Role, User, ProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<product> Products { get; set; }
        public DbSet<customer> Customers { get; set; }
        public DbSet<ProductMapping> ProductMappings { get; set; }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>(""); //Removes table prefixes. You can specify another prefix.
        }
    }
}

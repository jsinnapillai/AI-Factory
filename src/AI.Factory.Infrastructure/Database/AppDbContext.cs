using AI.Factory.Core.Entities;
using AI.Factory.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Project> Projects => Set<Project>();

        public DbSet<ApplicationContext> ApplicationContexts => Set<ApplicationContext>();

        public DbSet<ExecutionGraphEntity> ExecutionGraphs { get; set; }

        public DbSet<ExecutionNodeEntity> ExecutionNodes { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExecutionNodeEntity>()
                .HasOne(n => n.Graph)
                .WithMany(g => g.Nodes)
                .HasForeignKey(n => n.GraphId);
        }
    }

}
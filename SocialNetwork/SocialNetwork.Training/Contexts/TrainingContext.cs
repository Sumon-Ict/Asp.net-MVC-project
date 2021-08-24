using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Training.Entities;



namespace SocialNetwork.Training.Contexts
{
  public   class TrainingContext : DbContext, ITrainingContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrainingContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           
        //}


       
       
        public DbSet<Member> Members { get; set; }


    }
}

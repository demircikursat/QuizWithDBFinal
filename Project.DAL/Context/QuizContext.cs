using Project.DAL.StrategyPattern;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class QuizContext : DbContext
    {
        public QuizContext() : base("MyConnection")
        {
            Database.SetInitializer(new MyInit());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


        }
        public DbSet<Question> Question { get; set; }
        public DbSet<Option> Option { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

    }
}

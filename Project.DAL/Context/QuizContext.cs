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
            modelBuilder.Entity<AppUserScore>().Ignore(x => x.ID);
            modelBuilder.Entity<AppUserScore>().HasKey(x => new
            {
                x.AppUserID,
                x.ScoreID
            });

        }
        public DbSet<Question> Question { get; set; }
        public DbSet<Option> Option { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        
        public DbSet<Score> Score { get; set; }
        public DbSet<AppUserScore> AppUserScore { get; set; }
    }
}

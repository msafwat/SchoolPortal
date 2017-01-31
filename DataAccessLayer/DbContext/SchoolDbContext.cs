using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbContexts
{
    internal class SchoolDbContext : DbContext
    {
        internal DbSet<QuestionType> QuestionTypes;

        internal DbSet<QuestionLevel> QuestionLevels;

        internal DbSet<Question> Questions;

        internal DbSet<Answer> Students;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionType>().ToTable("Question_Type");
            modelBuilder.Entity<QuestionLevel>().ToTable("Question_Level");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Answer>().ToTable("Answer");

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Entities;
using Entities.QuestionsBank;
using Entities.School;
using Entities.SchoolStakeholders;
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
        internal SchoolDbContext(string connectionString) : base(connectionString)
        {
        }

        internal DbSet<School> Schools;

        //internal DbSet<QuestionType> QuestionTypes;

        //internal DbSet<QuestionLevel> QuestionLevels;

        //internal DbSet<Question> Questions;

        //internal DbSet<Answer> Answers;

        //internal DbSet<Student> Students;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>().ToTable("School");

            //modelBuilder.Entity<QuestionType>().ToTable("Question_Type");
            //modelBuilder.Entity<QuestionLevel>().ToTable("Question_Level");
            //modelBuilder.Entity<Question>().ToTable("Question");
            //modelBuilder.Entity<Answer>().ToTable("Answer");
            //modelBuilder.Entity<Student>().ToTable("Student");

            base.OnModelCreating(modelBuilder);
        }
    }
}

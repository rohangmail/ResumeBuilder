using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginFormInMvc.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> stud { get; set; }
        public DbSet<StudentMarks> Marks { get; set; }
        public DbSet<StudentExperience> Experience { get; set; }
        public DbSet<CardModel> cardModels { get; set; }
    }

}
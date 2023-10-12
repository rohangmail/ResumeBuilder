using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LoginFormInMvc.Models
{
    public class SignupLoginEntities : DbContext
    {
        public SignupLoginEntities() : base("SignupLoginEntities") 
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginFormInMvc.Models
{
    public class StudentExperience
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Experience Feild Required")]
        public bool HasWorkExperience { get; set; }
        
        public string CompanyName { get; set; }
    }
}
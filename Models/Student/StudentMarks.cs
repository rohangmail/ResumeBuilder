using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginFormInMvc.Models
{
    public class StudentMarks
    {
    
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "SSC Marks Required")]
        public int SSCPercentage { get; set; }

        [Required(ErrorMessage = "HSC Marks Required")]
        public int HSCPercentage { get; set; }
    }
}
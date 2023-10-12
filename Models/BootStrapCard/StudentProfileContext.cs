using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginFormInMvc.Models
{
    public class StudentProfile
    {
       
        [Key]
        public int StudentProfileId { get; set; }
        public List<Student> StudentInfo { get; set; }
        public List<StudentMarks> StudentMark { get; set; }
        public List<StudentExperience> StudnetExp { get; set; }

    }
}
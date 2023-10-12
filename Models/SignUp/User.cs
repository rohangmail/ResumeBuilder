using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginFormInMvc.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name Required")]

        public string LastName { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender Required")]

        public string Gender { get; set; }

        [DisplayName("Age")]
        [Required(ErrorMessage = "Age Required")]
        public int Age { get; set; }

        [DisplayName("Email Id")]
        [Required(ErrorMessage = "Email Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
        ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required")]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage = "PassWord is not similar")]
        public string ConfirmPassword { get; set; }

    }
}
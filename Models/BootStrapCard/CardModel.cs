using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginFormInMvc.Models
{
    public class CardModel
    {
        [Key]
        public int CardId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int SSCPercentage { get; set; }
        public int HSCPercentage { get; set; }
        public bool HasWorkExperience { get; set; }
        public string CompanyName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvolentDemo.Models
{
    public class Contact
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ? Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name Required!")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required!")]
        public string Last_Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email Required!")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Phone_Number { get; set; }

        [Required(ErrorMessage = "Status Required!")]
        public string Status { get; set; }
       
    }
}
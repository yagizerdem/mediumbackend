using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3 ,ErrorMessage ="min user first name lenght is 3")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "min user last name lenght is 3")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$" ,ErrorMessage = """
             Should have at least one lower case
             Should have at least one upper case
             Should have at least one number
              Should have at least one special character
             Minimum 8 characters
            """)]
        public string Password { get; set; }

        [NotMapped]
        public string PasswordAgain { get; set; }

        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}";
        [NotMapped]
        public bool isPasswordMatch => this.Password == this.PasswordAgain;


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class RegisterModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Minimum first name length is 3")]
        [MaxLength(30, ErrorMessage = "Maximum first name length is 30")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minimum last name length is 3")]
        [MaxLength(30, ErrorMessage = "Maximum last name length is 30")]
        public string LastName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minimum user name length is 3")]
        [MaxLength(30, ErrorMessage = "Maximum user name length is 30")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

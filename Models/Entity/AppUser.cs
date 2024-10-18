using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entity
{
    public class AppUser : IdentityUser
    {
        [MinLength(3,ErrorMessage ="min first name lenght is 3")]
        [MaxLength(30 , ErrorMessage ="max last name length is 30")]
        public string FirstName { get; set; }
        [MaxLength(30, ErrorMessage = "max last name length is 30")]
        [MinLength(3, ErrorMessage = "min last name lenght is 3")]
        public string LastName { get; set; }

        public List<Article> Articles { get; set; }
        public List<Like> Likes { get; set; }

        public List<Comment> Comments { get; set; }
    }
}

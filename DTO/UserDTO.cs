using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; } = null!;

        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        public string Password { get; set; } = null!;

     

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Businessmall.DTOs.Users
{
    public class AddUserCommand
    {
        [Required]
        public string FirstName {get;set;}

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password {get; set;}
    }
}
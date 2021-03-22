using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Altamira.Entities.Abstract
{
    interface IAuthenticateRequest
    {

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}

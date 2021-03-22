using Altamira.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Altamira.Entities.Concrete
{
    public class User : IUser
    {
        [Key]
        public int id { get ; set ; }
        public string name { get ; set ; }
        public string username { get ; set ; }
        [Required]
        public string email { get ; set ; }
        public string password { get; set; }
        //public int addressrefid { get ; set ; }
        public string phone { get ; set ; }
        public string website { get ; set ; }
        //public int companyrefid { get ; set ; }
        public Company company { get ; set ; }
        public Address address { get; set; }
    }
}

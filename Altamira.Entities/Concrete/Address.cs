using Altamira.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Altamira.Entities.Concrete
{
    public class Address : IAddress
    {
        [Key]
        public int addressid { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
        ICollection<User> IAddress.Users { get; set; }
    }
}

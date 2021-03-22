using Altamira.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altamira.Entities.Abstract
{
    interface IAddress
    {
        public int addressid { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        //public int georefid { get; set; }
        public Geo geo { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

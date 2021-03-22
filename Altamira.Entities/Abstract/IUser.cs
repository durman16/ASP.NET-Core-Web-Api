using Altamira.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altamira.Entities.Abstract
{
    interface IUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        //public int addressrefid { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        //public int companyrefid { get; set; }
        public Company company { get; set; }
    }
}

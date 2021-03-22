using Altamira.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Altamira.Entities.Concrete
{
    public class Company : ICompany
    {
        [Key]
        public int companyid { get; set; }
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
        ICollection<User> ICompany.Users { get; set; }
    }
}

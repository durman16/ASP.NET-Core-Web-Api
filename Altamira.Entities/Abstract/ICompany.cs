using Altamira.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altamira.Entities.Abstract
{
    interface ICompany
    {
        public int companyid { get; set; }
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

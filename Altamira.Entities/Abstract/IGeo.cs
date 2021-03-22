using Altamira.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altamira.Entities.Abstract
{
    interface IGeo
    {
        public int geoid { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public ICollection<Address> addresses { get; set; }
    }
}

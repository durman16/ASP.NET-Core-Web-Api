using Altamira.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Altamira.Entities.Concrete
{
    public class Geo : IGeo
    {
        [Key]
        public int geoid { get ; set ; }
        public string lat { get ; set ; }
        public string lng { get ; set ; }
        ICollection<Address> IGeo.addresses { get; set; }
    }
}

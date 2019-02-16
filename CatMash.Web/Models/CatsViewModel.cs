using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Web.Models
{
    public class CatViewModel
    {
        public string Identifier { get; set; }
        public Uri ImageUrl { get; set; }
        public int Votes { get; set; }
    }
}

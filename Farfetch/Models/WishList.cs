using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Farfetch.Models
{
    public class WishList
    {
        [Key]
        public int WishId { get; set; }

        public string Name { get; set; }
        
    }
}

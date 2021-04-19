using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Farfetch.Models
{
    public class ItemDTO
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string BrandName { get; set; }
        public string Designer { get; set; }
        public string Color { get; set; }
        public string Season { get; set; }

    }
}


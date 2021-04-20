using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farfetch.Models
{
    public class List
    {
        [Key]
        public int ListId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        [ForeignKey("WishList")]
        public int WishId { get; set; }

    }
}

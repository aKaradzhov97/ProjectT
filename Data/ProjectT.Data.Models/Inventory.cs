using System;

namespace ProjectT.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Inventory
    {
        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public string StoreId { get; set; }

        public virtual Store Store { get; set; }

        public int StockAvailable { get; set; }

        public DateTime Created_On { get; set; }
    }
}
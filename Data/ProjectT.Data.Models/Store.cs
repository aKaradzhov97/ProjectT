namespace ProjectT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Store
    {
        public Store()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Carts = new HashSet<Cart>();
            this.Inventories = new HashSet<Inventory>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        public DateTime Created_On { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
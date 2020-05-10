namespace ProjectT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Carts = new HashSet<Cart>();
            this.Inventories = new HashSet<Inventory>();
            this.OrderItems = new HashSet<OrderItem>();
            this.Images = new HashSet<Image>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 100000.00)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 100000)]
        public int Quantity { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public DateTime Created_On { get; set; }

        public int SellCount { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
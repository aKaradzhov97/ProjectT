namespace ProjectT.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrderItem
    {
        public OrderItem()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal Price { get; set; }

        public DateTime Created_On { get; set; }

        [Required]
        public string OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
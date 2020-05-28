namespace ProjectT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public DateTime Created_On { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(6)]
        public string Post_Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address_State { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address_Country { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
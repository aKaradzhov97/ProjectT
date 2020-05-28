namespace ProjectT.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.SubCategories = new HashSet<SubCategory>();
            this.Products = new HashSet<Product>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public DateTime Created_On { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
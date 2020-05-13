namespace ProjectT.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Url { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
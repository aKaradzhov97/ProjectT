using System;
using System.Collections.Generic;

namespace ProjectT.Data.Models
{
    public class SubCategory
    {
        public SubCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Created_On { get; set; }

        public virtual Category Category { get; set; }
    }
}
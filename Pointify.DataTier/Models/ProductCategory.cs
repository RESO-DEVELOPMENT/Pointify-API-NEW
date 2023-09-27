using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public Guid ProductCateId { get; set; }
        public Guid BrandId { get; set; }
        public string CateId { get; set; } = null!;
        public string? Name { get; set; }
        public bool DelFlg { get; set; }
        public DateTime UpdDate { get; set; }
        public DateTime InsDate { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}

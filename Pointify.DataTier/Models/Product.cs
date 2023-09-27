using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Product
    {
        public Product()
        {
            ActionProductMappings = new HashSet<ActionProductMapping>();
            GiftProductMappings = new HashSet<GiftProductMapping>();
            ProductConditionMappings = new HashSet<ProductConditionMapping>();
        }

        public Guid ProductId { get; set; }
        public Guid ProductCateId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public int? ProductType { get; set; }

        public virtual ProductCategory ProductCate { get; set; } = null!;
        public virtual ICollection<ActionProductMapping> ActionProductMappings { get; set; }
        public virtual ICollection<GiftProductMapping> GiftProductMappings { get; set; }
        public virtual ICollection<ProductConditionMapping> ProductConditionMappings { get; set; }
    }
}

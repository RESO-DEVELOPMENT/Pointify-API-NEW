using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class ProductCondition
    {
        public ProductCondition()
        {
            ProductConditionMappings = new HashSet<ProductConditionMapping>();
        }

        public Guid ProductConditionId { get; set; }
        public Guid ConditionGroupId { get; set; }
        public int IndexGroup { get; set; }
        public int ProductConditionType { get; set; }
        public int ProductQuantity { get; set; }
        public string QuantityOperator { get; set; } = null!;
        public int NextOperator { get; set; }
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }

        public virtual ConditionGroup ConditionGroup { get; set; } = null!;
        public virtual ICollection<ProductConditionMapping> ProductConditionMappings { get; set; }
    }
}

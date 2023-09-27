using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class ConditionGroup
    {
        public ConditionGroup()
        {
            OrderConditions = new HashSet<OrderCondition>();
            ProductConditions = new HashSet<ProductCondition>();
        }

        public Guid ConditionGroupId { get; set; }
        public Guid ConditionRuleId { get; set; }
        public int GroupNo { get; set; }
        public int NextOperator { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public string? Summary { get; set; }

        public virtual ConditionRule ConditionRule { get; set; } = null!;
        public virtual ICollection<OrderCondition> OrderConditions { get; set; }
        public virtual ICollection<ProductCondition> ProductConditions { get; set; }
    }
}

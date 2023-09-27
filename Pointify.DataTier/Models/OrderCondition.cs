using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class OrderCondition
    {
        public Guid OrderConditionId { get; set; }
        public Guid ConditionGroupId { get; set; }
        public int NextOperator { get; set; }
        public int IndexGroup { get; set; }
        public int Quantity { get; set; }
        public string QuantityOperator { get; set; } = null!;
        public decimal Amount { get; set; }
        public string AmountOperator { get; set; } = null!;
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }

        public virtual ConditionGroup ConditionGroup { get; set; } = null!;
    }
}

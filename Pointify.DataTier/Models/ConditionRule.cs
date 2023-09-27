using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class ConditionRule
    {
        public ConditionRule()
        {
            ConditionGroups = new HashSet<ConditionGroup>();
            PromotionTiers = new HashSet<PromotionTier>();
        }

        public Guid ConditionRuleId { get; set; }
        public Guid BrandId { get; set; }
        public string RuleName { get; set; } = null!;
        public string? Description { get; set; }
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<ConditionGroup> ConditionGroups { get; set; }
        public virtual ICollection<PromotionTier> PromotionTiers { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Action
    {
        public Action()
        {
            ActionProductMappings = new HashSet<ActionProductMapping>();
            PromotionTiers = new HashSet<PromotionTier>();
            VoucherGroups = new HashSet<VoucherGroup>();
        }

        public Guid ActionId { get; set; }
        public int ActionType { get; set; }
        public int? DiscountQuantity { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? FixedPrice { get; set; }
        public decimal? MaxAmount { get; set; }
        public decimal? MinPriceAfter { get; set; }
        public int? OrderLadderProduct { get; set; }
        public decimal? LadderPrice { get; set; }
        public decimal? BundlePrice { get; set; }
        public int? BundleQuantity { get; set; }
        public int? BundleStrategy { get; set; }
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public string? Name { get; set; }
        public Guid? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ICollection<ActionProductMapping> ActionProductMappings { get; set; }
        public virtual ICollection<PromotionTier> PromotionTiers { get; set; }
        public virtual ICollection<VoucherGroup> VoucherGroups { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Gift
    {
        public Gift()
        {
            GiftProductMappings = new HashSet<GiftProductMapping>();
            PromotionTiers = new HashSet<PromotionTier>();
            VoucherGroups = new HashSet<VoucherGroup>();
        }

        public Guid GiftId { get; set; }
        public int PostActionType { get; set; }
        public decimal? BonusPoint { get; set; }
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public Guid? GiftVoucherGroupId { get; set; }
        public string? Name { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? GameCampaignId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual GameCampaign? GameCampaign { get; set; }
        public virtual ICollection<GiftProductMapping> GiftProductMappings { get; set; }
        public virtual ICollection<PromotionTier> PromotionTiers { get; set; }
        public virtual ICollection<VoucherGroup> VoucherGroups { get; set; }
    }
}

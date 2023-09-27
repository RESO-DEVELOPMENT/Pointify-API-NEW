using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            GameCampaigns = new HashSet<GameCampaign>();
            MemberLevelMappings = new HashSet<MemberLevelMapping>();
            PromotionChannelMappings = new HashSet<PromotionChannelMapping>();
            PromotionStoreMappings = new HashSet<PromotionStoreMapping>();
            PromotionTiers = new HashSet<PromotionTier>();
            Vouchers = new HashSet<Voucher>();
        }

        public Guid PromotionId { get; set; }
        public Guid BrandId { get; set; }
        public string PromotionCode { get; set; } = null!;
        public string PromotionName { get; set; } = null!;
        public int ActionType { get; set; }
        public int PostActionType { get; set; }
        public string? ImgUrl { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Exclusive { get; set; }
        public int ApplyBy { get; set; }
        public int SaleMode { get; set; }
        public int Gender { get; set; }
        public int PaymentMethod { get; set; }
        public int ForHoliday { get; set; }
        public int ForMembership { get; set; }
        public int DayFilter { get; set; }
        public int HourFilter { get; set; }
        public int Status { get; set; }
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public bool HasVoucher { get; set; }
        public bool IsAuto { get; set; }
        public int? PromotionType { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<GameCampaign> GameCampaigns { get; set; }
        public virtual ICollection<MemberLevelMapping> MemberLevelMappings { get; set; }
        public virtual ICollection<PromotionChannelMapping> PromotionChannelMappings { get; set; }
        public virtual ICollection<PromotionStoreMapping> PromotionStoreMappings { get; set; }
        public virtual ICollection<PromotionTier> PromotionTiers { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class GameCampaign
    {
        public GameCampaign()
        {
            GameItems = new HashSet<GameItem>();
            Gifts = new HashSet<Gift>();
            StoreGameCampaignMappings = new HashSet<StoreGameCampaignMapping>();
            Vouchers = new HashSet<Voucher>();
        }

        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public Guid GameMasterId { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public DateTime? StartGame { get; set; }
        public DateTime? EndGame { get; set; }
        public Guid? PromotionId { get; set; }
        public string? SecretCode { get; set; }
        public bool HasCode { get; set; }
        public int? ExpiredDuration { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual GameMaster GameMaster { get; set; } = null!;
        public virtual Promotion? Promotion { get; set; }
        public virtual ICollection<GameItem> GameItems { get; set; }
        public virtual ICollection<Gift> Gifts { get; set; }
        public virtual ICollection<StoreGameCampaignMapping> StoreGameCampaignMappings { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}

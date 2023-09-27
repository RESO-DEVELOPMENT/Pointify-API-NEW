using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Store
    {
        public Store()
        {
            Devices = new HashSet<Device>();
            PromotionStoreMappings = new HashSet<PromotionStoreMapping>();
            StoreGameCampaignMappings = new HashSet<StoreGameCampaignMapping>();
            Vouchers = new HashSet<Voucher>();
        }

        public Guid StoreId { get; set; }
        public Guid BrandId { get; set; }
        public string StoreCode { get; set; } = null!;
        public string StoreName { get; set; } = null!;
        public bool DelFlg { get; set; }
        public DateTime? InsDate { get; set; }
        public DateTime? UpdDate { get; set; }
        public int Group { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<PromotionStoreMapping> PromotionStoreMappings { get; set; }
        public virtual ICollection<StoreGameCampaignMapping> StoreGameCampaignMappings { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}

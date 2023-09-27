using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Channel
    {
        public Channel()
        {
            PromotionChannelMappings = new HashSet<PromotionChannelMapping>();
            Vouchers = new HashSet<Voucher>();
        }

        public Guid ChannelId { get; set; }
        public Guid? BrandId { get; set; }
        public string ChannelName { get; set; } = null!;
        public string ChannelCode { get; set; } = null!;
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public int? Group { get; set; }
        public int? ChannelType { get; set; }
        public string? ApiKey { get; set; }
        public string? PublicKey { get; set; }
        public string? PrivateKey { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ICollection<PromotionChannelMapping> PromotionChannelMappings { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}

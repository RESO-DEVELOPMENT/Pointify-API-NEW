using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class VoucherGroup
    {
        public VoucherGroup()
        {
            PromotionTiers = new HashSet<PromotionTier>();
            Vouchers = new HashSet<Voucher>();
        }

        public Guid VoucherGroupId { get; set; }
        public Guid BrandId { get; set; }
        public string VoucherName { get; set; } = null!;
        public int Quantity { get; set; }
        public int UsedQuantity { get; set; }
        public int RedempedQuantity { get; set; }
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public string? Charset { get; set; }
        public string? Postfix { get; set; }
        public string? Prefix { get; set; }
        public string? CustomCharset { get; set; }
        public Guid? ActionId { get; set; }
        public Guid? GiftId { get; set; }
        public int? CodeLength { get; set; }
        public string? ImgUrl { get; set; }

        public virtual Action? Action { get; set; }
        public virtual Brand Brand { get; set; } = null!;
        public virtual Gift? Gift { get; set; }
        public virtual ICollection<PromotionTier> PromotionTiers { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}

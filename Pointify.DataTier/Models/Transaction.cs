using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Transaction
    {
        public Guid Id { get; set; }
        public string TransactionJson { get; set; } = null!;
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public Guid? VoucherId { get; set; }
        public Guid? PromotionId { get; set; }
        public Guid? MemberActionId { get; set; }
        public Guid? MemberWalletId { get; set; }
        public Guid? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual MemberAction? MemberAction { get; set; }
        public virtual MemberWallet? MemberWallet { get; set; }
    }
}

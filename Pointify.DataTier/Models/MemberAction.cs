using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class MemberAction
    {
        public MemberAction()
        {
            Transactions = new HashSet<Transaction>();
        }

        public Guid Id { get; set; }
        public double? ActionValue { get; set; }
        public string? Status { get; set; }
        public string Description { get; set; } = null!;
        public bool? DelFlag { get; set; }
        public Guid? MemberWalletId { get; set; }
        public Guid? MemberActionTypeId { get; set; }
        public Guid? MemberShipCardId { get; set; }

        public virtual MemberActionType? MemberActionType { get; set; }
        public virtual MembershipCard? MemberShipCard { get; set; }
        public virtual MemberWallet? MemberWallet { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}

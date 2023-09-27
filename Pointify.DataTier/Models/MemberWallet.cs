using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class MemberWallet
    {
        public MemberWallet()
        {
            MemberActions = new HashSet<MemberAction>();
            Transactions = new HashSet<Transaction>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? DelFlag { get; set; }
        public Guid? MemberId { get; set; }
        public Guid? WalletTypeId { get; set; }
        public double Balance { get; set; }
        public double? BalanceHistory { get; set; }

        public virtual Member? Member { get; set; }
        public virtual WalletType? WalletType { get; set; }
        public virtual ICollection<MemberAction> MemberActions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}

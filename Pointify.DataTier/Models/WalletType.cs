using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class WalletType
    {
        public WalletType()
        {
            MemberActionTypes = new HashSet<MemberActionType>();
            MemberWallets = new HashSet<MemberWallet>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid MemberShipProgramId { get; set; }
        public bool? DelFlag { get; set; }
        public string? Currency { get; set; }

        public virtual MembershipProgram MemberShipProgram { get; set; } = null!;
        public virtual ICollection<MemberActionType> MemberActionTypes { get; set; }
        public virtual ICollection<MemberWallet> MemberWallets { get; set; }
    }
}

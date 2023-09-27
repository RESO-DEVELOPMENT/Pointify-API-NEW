using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Member
    {
        public Member()
        {
            MemberWallets = new HashSet<MemberWallet>();
            MembershipCards = new HashSet<MembershipCard>();
        }

        public Guid Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public bool? DelFlg { get; set; }
        public DateTime? InsDate { get; set; }
        public DateTime? UpdDate { get; set; }
        public Guid? MemberProgramId { get; set; }
        public Guid? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual MembershipProgram? MemberProgram { get; set; }
        public virtual ICollection<MemberWallet> MemberWallets { get; set; }
        public virtual ICollection<MembershipCard> MembershipCards { get; set; }
    }
}

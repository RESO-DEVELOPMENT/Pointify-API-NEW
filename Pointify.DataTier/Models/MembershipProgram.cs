using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class MembershipProgram
    {
        public MembershipProgram()
        {
            MemberActionTypes = new HashSet<MemberActionType>();
            Members = new HashSet<Member>();
            MembershipCardTypes = new HashSet<MembershipCardType>();
            WalletTypes = new HashSet<WalletType>();
        }

        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public string? NameOfProgram { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? EndDay { get; set; }
        public bool? DelFlg { get; set; }
        public string? TermAndConditions { get; set; }
        public string? Status { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<MemberActionType> MemberActionTypes { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<MembershipCardType> MembershipCardTypes { get; set; }
        public virtual ICollection<WalletType> WalletTypes { get; set; }
    }
}

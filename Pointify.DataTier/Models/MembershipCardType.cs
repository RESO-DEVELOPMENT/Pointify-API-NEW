using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class MembershipCardType
    {
        public MembershipCardType()
        {
            MembershipCards = new HashSet<MembershipCard>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? AppendCode { get; set; }
        public Guid MemberShipProgramId { get; set; }
        public bool Active { get; set; }
        public string? CardImg { get; set; }

        public virtual MembershipProgram MemberShipProgram { get; set; } = null!;
        public virtual ICollection<MembershipCard> MembershipCards { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class MembershipCard
    {
        public MembershipCard()
        {
            MemberActions = new HashSet<MemberAction>();
        }

        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public string MembershipCardCode { get; set; } = null!;
        public bool? Active { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid BrandId { get; set; }
        public Guid MembershipCardTypeId { get; set; }
        public string? PhysicalCardCode { get; set; }
        public Guid MemberShipCardLevelId { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual MembershipLevel MemberShipCardLevel { get; set; } = null!;
        public virtual MembershipCardType MembershipCardType { get; set; } = null!;
        public virtual ICollection<MemberAction> MemberActions { get; set; }
    }
}

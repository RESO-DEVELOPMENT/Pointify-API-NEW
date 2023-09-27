using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class MemberActionType
    {
        public MemberActionType()
        {
            MemberActions = new HashSet<MemberAction>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? DelFlag { get; set; }
        public Guid? MemberShipProgramId { get; set; }

        public virtual MembershipProgram? MemberShipProgram { get; set; }
        public virtual ICollection<MemberAction> MemberActions { get; set; }
    }
}

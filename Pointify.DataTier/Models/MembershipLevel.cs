﻿using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class MembershipLevel
    {
        public MembershipLevel()
        {
            Members = new HashSet<Member>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? DelFlag { get; set; }
        public int? MaxPoint { get; set; }
        public Guid? MembershipCardId { get; set; }
        public string? Status { get; set; }
        public double? PointRedeemRate { get; set; }
        public int? LevelRank { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}

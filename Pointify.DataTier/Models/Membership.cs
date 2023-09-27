using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Membership
    {
        public Membership()
        {
            Vouchers = new HashSet<Voucher>();
        }

        public Guid MembershipId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string Fullname { get; set; } = null!;
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}

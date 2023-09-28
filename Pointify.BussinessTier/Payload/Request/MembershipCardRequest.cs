using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Request
{
    public class MembershipCardRequest
    {
        public Guid MemberId { get; set; }
        public string MembershipCardCode { get; set; }
        public bool? Active { get; set; }
        public Guid BrandId { get; set; }
        public Guid MembershipCardTypeId { get; set; }
        public string? PhysicalCardCode { get; set; }


        public MembershipCardRequest(Guid memberId, Guid brandId, Guid membershipCardTypeId, string physicalCardCode, string membershipCardCode)
        {
            MemberId = memberId;
            BrandId = brandId;
            MembershipCardTypeId = membershipCardTypeId;
            PhysicalCardCode = physicalCardCode;
            MembershipCardCode = membershipCardCode;
        }
    }

    public class UpdMembershipCardRequest
    {
        public string MembershipCardCode { get; set; } = null!;
        public bool? Active { get; set; }
    }
}
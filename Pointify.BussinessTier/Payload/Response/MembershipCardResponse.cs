using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Response
{
    public class MembershipCardResponse
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public string MembershipCardCode { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedTime { get; set; }
        public Guid BrandId { get; set; }
        public Guid MembershipCardTypeId { get; set; }
        public string? PhysicalCardCode { get; set; }

        public MembershipCardResponse(Guid Id, Guid MemberId, string MembershipCardCode, bool? Active,
            DateTime? CreatedTime, Guid BrandId, Guid MembershipCardTypeId, string PhysicalCardCode
        )
        {
            this.Id = Id;
            this.MemberId = MemberId;
            this.MembershipCardCode = MembershipCardCode;
            this.Active = Active;
            this.CreatedTime = CreatedTime;
            this.BrandId = BrandId;
            this.MembershipCardTypeId = MembershipCardTypeId;
            this.PhysicalCardCode = PhysicalCardCode;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Request.MemberActionType
{
    public class GetMemberActionTypeRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? DelFlag { get; set; }
        public Guid? MemberShipProgramId { get; set; }
        public Guid? MemberWalletTypeId { get; set; }
        public string? Code { get; set; }
    }
}

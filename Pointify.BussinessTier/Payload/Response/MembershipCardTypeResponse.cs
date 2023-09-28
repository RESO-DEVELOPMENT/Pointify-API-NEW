using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Response
{
    public class MembershipCardTypeResponse
    {
        public Guid Id { get; set; }
        public Guid? AppendCode { get; set; }
        public Guid MemberShipProgramId { get; set; }
        public string Name { get; set; }
        public string? CardImg { get; set; }
        public bool? Active { get; set; }
        public MembershipCardTypeResponse(Guid id, Guid? appendCode, Guid memberShipProgramId, string name, string? cardImg, bool? active)
        {
            Id = id;
            AppendCode = appendCode;
            Name = name;
            CardImg = cardImg;
            Active = active;
            MemberShipProgramId = memberShipProgramId;
        }
    }
}

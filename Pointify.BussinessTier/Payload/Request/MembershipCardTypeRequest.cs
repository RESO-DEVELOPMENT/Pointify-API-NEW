using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Request
{
    public class MembershipCardTypeRequest
    {
        public Guid Id { get; set; }
        public Guid? AppendCode { get; set; }
        public Guid MemberShipProgramId { get; set; }
        public string Name { get; set; }
        public string? CardImg { get; set; }
        public bool? Active { get; set; }
    }
}

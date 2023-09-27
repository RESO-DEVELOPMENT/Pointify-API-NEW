using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Request.WalletType
{
    public class GetWallTypeRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid MemberShipProgramId { get; set; }
        public bool? DelFlag { get; set; }
    }
}

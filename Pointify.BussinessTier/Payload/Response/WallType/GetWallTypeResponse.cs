using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Response.WallType
{
    public class GetWallTypeResponse
    {
        public GetWallTypeResponse(Guid id, string? name, Guid memberShipProgramId)
        {
            Id = id;
            Name = name;
            MemberShipProgramId = memberShipProgramId;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid MemberShipProgramId { get; set; }
    }
}

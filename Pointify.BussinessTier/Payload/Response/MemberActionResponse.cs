using Pointify.DataTier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Response
{
    public class MemberActionResponse
    {
        public Guid transactionId { get; set; }
        public Member member { get; set; }

    }
}

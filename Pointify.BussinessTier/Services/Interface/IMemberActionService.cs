using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pointify.BussinessTier.Payload.Request;
using Pointify.DataTier.Models;

namespace Pointify.BussinessTier.Services.Interface
{
    public interface IMemberActionService
    {
        public Task<MemberAction?> CreateMemberAction(MemberActionRequest request);
    }
}
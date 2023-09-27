using Pointify.BussinessTier.Payload.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Services.Interface
{
    public interface IStoreService
    {
        public Task<ScanMemberResponse> ScanMembershipCard(string code);
    }
}

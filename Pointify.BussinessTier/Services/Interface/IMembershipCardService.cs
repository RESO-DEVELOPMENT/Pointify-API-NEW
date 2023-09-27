using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Services.Interface
{
    public interface IMembershipCardService
    {
        public Task<MembershipCardResponse> CreateMembershipCard(MembershipCardRequest res);
        public Task<bool> DeleteMembershipCard(Guid id);
        public Task<MembershipCardResponse> GetMembershipCardById(Guid id);
        public Task<IPaginate<MembershipCardResponse>> GetMembershipCard(int page, int size);
    }
}

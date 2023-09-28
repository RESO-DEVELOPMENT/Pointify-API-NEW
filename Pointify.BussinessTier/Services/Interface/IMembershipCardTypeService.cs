using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;

namespace Pointify.BussinessTier.Services.Interface
{
    public interface IMembershipCardTypeService
    {
        public Task<MembershipCardTypeResponse> CreateMembershipCardType(MembershipCardTypeRequest res);
        public Task<bool> DeleteMembershipCardType(Guid id);
        public Task<MembershipCardTypeResponse> GetMembershipCardTypeById(Guid id);
        public Task<IPaginate<MembershipCardTypeResponse>> GetMembershipCardType(int page, int size);
    }
}

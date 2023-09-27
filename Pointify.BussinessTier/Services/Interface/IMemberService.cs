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
    public interface IMemberService
    {
        public Task<MemberResponse> CreateMember(MemberRequest res);
        public Task<MemberResponse> UpdateMember(Guid id, MemberRequest res);
        public Task<bool> DeleteMember(Guid id);
        public Task<MemberResponse> GetMemberById(Guid id);
        public Task<IPaginate<MemberResponse>> GetMember(int page, int size);
    }
}

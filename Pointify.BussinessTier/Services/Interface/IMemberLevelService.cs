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
    public interface IMemberLevelService
    {
        public Task<MemberLevelResponse> CreateMemberLevel(MemberLevelRequest res);
        public Task<bool> DeleteMemberLevel(Guid id);
        public Task<MemberLevelResponse> GetMemberLevelById(Guid id);
        public Task<IPaginate<MemberLevelResponse>> GetMemberLevel(int page, int size);
    }
}

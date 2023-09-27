using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request.MemberActionType;
using Pointify.BussinessTier.Payload.Response.MemberActionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Services.Interface
{
    public interface IMemberActionTypeService
    {
        public Task<IPaginate<GetMemberActionTypeResponse>> GetActionTypes(string? searchActionName, int page,
      int size);
        public Task<GetMemberActionTypeResponse> CreateActionType(GetMemberActionTypeRequest newAction);
        public Task<GetMemberActionTypeResponse> UpdateAction(Guid id, GetMemberActionTypeRequest updateNewAction);
        public Task<GetMemberActionTypeResponse> GetActionDetail(Guid id);
        public Task<GetMemberActionTypeResponse> HideAction(Guid id);
    }
}

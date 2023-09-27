using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request.MemberActionType;
using Pointify.BussinessTier.Payload.Response.MemberActionType;
using Pointify.BussinessTier.Services.Interface;
using Pointify.BussinessTier.UnitOfWork.Interface;
using Pointify.DataTier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Services.Implement
{
    public class MemberActionTypeService : BaseService<MemberActionTypeService>, IMemberActionTypeService
    {
        public MemberActionTypeService(IUnitOfWork<PromotionEngineContext> unitOfWork, ILogger<MemberActionTypeService> logger) 
            : base(unitOfWork, logger)
        {
        }

        public async Task<IPaginate<GetMemberActionTypeResponse>> GetActionTypes(string? searchActionName, int page,
        int size)
        {
            searchActionName = searchActionName?.Trim().ToLower();
            IPaginate<GetMemberActionTypeResponse> program = await _unitOfWork.GetRepository<MemberActionType>()
                .GetPagingListAsync(
                    selector: x => new GetMemberActionTypeResponse(x.Id, x.Name, x.MemberShipProgramId, x.MemberWalletTypeId, x.Code
                    ),
                    predicate:
                    string.IsNullOrEmpty(searchActionName)
                        ? x => true
                        : x => x.Name.ToLower().Contains(searchActionName),
                    page:
                    page,
                    size:
                    size);
            return program;
        }

        public async Task<GetMemberActionTypeResponse> CreateActionType(GetMemberActionTypeRequest newAction)
        {
            MemberActionType action = new MemberActionType()
            {
                Id = Guid.NewGuid(),
                Name = newAction.Name,
                DelFlag = false,
                MemberShipProgramId = newAction.MemberShipProgramId,
                MemberWalletTypeId = newAction.MemberWalletTypeId,
                Code = newAction.Code
            };
            await _unitOfWork.GetRepository<MemberActionType>().InsertAsync(action);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return null;
            return new GetMemberActionTypeResponse(newAction.Id, newAction.Name, newAction.MemberShipProgramId,newAction.MemberWalletTypeId, newAction.Code);
        }

        public async Task<GetMemberActionTypeResponse> UpdateAction(Guid id, GetMemberActionTypeRequest updateNewAction)
        {
            MemberActionType updateAction = await _unitOfWork.GetRepository<MemberActionType>().SingleOrDefaultAsync(predicate: x => x.Id.Equals(id));
            //if (updateProduct == null) 
            updateAction.Id = updateNewAction.Id;
            updateAction.Code = updateNewAction.Code;
            updateAction.MemberShipProgramId = updateNewAction.MemberShipProgramId;
            updateAction.MemberWalletTypeId = updateNewAction.MemberWalletTypeId;
            updateAction.Name = updateNewAction.Name;
            updateAction.DelFlag = false;
            _unitOfWork.GetRepository<MemberActionType>().UpdateAsync(updateAction);
            await _unitOfWork.CommitAsync();
            return new GetMemberActionTypeResponse(updateAction.Id, updateAction.Name, updateAction.MemberShipProgramId, 
                                                    updateAction.MemberWalletTypeId, updateAction.Code);

        }

        public async Task<GetMemberActionTypeResponse> GetActionDetail(Guid id)
        {
            GetMemberActionTypeResponse program = await _unitOfWork.GetRepository<MemberActionType>().SingleOrDefaultAsync(
                selector: x => new GetMemberActionTypeResponse(x.Id, x.Name, x.MemberShipProgramId, x.MemberWalletTypeId, x.Code),
                predicate: x => x.Id.Equals(id),
                include: x => x.Include(x => x.MemberActions)
                );
            return program;
        }

        public async Task<GetMemberActionTypeResponse> HideAction(Guid id)
        {
            MemberActionType updateAction = await _unitOfWork.GetRepository<MemberActionType>().SingleOrDefaultAsync(predicate: x => x.Id.Equals(id));
            //if (updateProduct == null) 
            updateAction.Id = updateAction.Id;
            updateAction.Name = updateAction.Name;
            updateAction.MemberShipProgramId = updateAction.MemberShipProgramId;
            updateAction.MemberWalletTypeId = updateAction.MemberWalletTypeId;
            updateAction.Code = updateAction.Code;
            if (updateAction.DelFlag == false)
            {
                updateAction.DelFlag = true;
            }
            else
            {
                updateAction.DelFlag = false;
            }
            _unitOfWork.GetRepository<MemberActionType>().UpdateAsync(updateAction);
            await _unitOfWork.CommitAsync();
            return new GetMemberActionTypeResponse(updateAction.Id, updateAction.Name, updateAction.MemberShipProgramId, updateAction.MemberWalletTypeId, updateAction.Code);
        }
    }
}

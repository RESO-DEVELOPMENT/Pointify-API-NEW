using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using Pointify.BussinessTier.UnitOfWork.Interface;
using Pointify.BussinessTier.Util;
using Pointify.DataTier.Models;

namespace Pointify.BussinessTier.Services.Implement
{
    public class MembershipCardTypeService : BaseService<MembershipCardTypeService>, IMembershipCardTypeService
    {
        public MembershipCardTypeService(IUnitOfWork<PromotionEngineContext> unitOfWork, ILogger<MembershipCardTypeService> logger) : base(unitOfWork, logger)
        {
        }

        public async Task<MembershipCardTypeResponse> CreateMembershipCardType(MembershipCardTypeRequest res)
        {
            MembershipCardType newMembershipCardType = new MembershipCardType()
            {
                Id = Guid.NewGuid(),
                Name = res.Name,
                Active = true,
                AppendCode = Guid.NewGuid(),
                CardImg = res.CardImg,
                MemberShipProgramId = res.MemberShipProgramId,
            };
            await _unitOfWork.GetRepository<MembershipCardType>().InsertAsync(newMembershipCardType);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return null;
            return new MembershipCardTypeResponse(newMembershipCardType.Id, newMembershipCardType.AppendCode,
                newMembershipCardType.MemberShipProgramId, newMembershipCardType.Name,
                newMembershipCardType.CardImg,  newMembershipCardType.Active);
        }

        public async Task<bool> DeleteMembershipCardType(Guid id)
        {
            MembershipCardType type = await _unitOfWork.GetRepository<MembershipCardType>().SingleOrDefaultAsync(
                               selector: x => x,
                                              predicate: x => x.Id.Equals(id)
                                                         );
            if (type == null) return false;
            type.Active = false;
            _unitOfWork.GetRepository<MembershipCardType>().UpdateAsync(type);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return false;
            return true;
        }

        public async Task<MembershipCardTypeResponse> GetMembershipCardTypeById(Guid id)
        {
            MembershipCardTypeResponse res = await _unitOfWork.GetRepository<MembershipCardType>()
                .SingleOrDefaultAsync(selector: x => new MembershipCardTypeResponse(
                    x.Id, x.AppendCode, x.MemberShipProgramId, x.Name, x.CardImg, x.Active), predicate: x => (x.Id.Equals(id)));
            return res;
        }
        public async Task<IPaginate<MembershipCardTypeResponse>> GetMembershipCardType(int page, int size)
        {
            IPaginate<MembershipCardTypeResponse> ListType =
            await _unitOfWork.GetRepository<MembershipCardType>().GetPagingListAsync(
                selector: x => new MembershipCardTypeResponse(x.Id, x.AppendCode, x.MemberShipProgramId, x.Name, x.CardImg, x.Active),
                predicate: x => x.Active == true,
                page: page,
                size: size
                );
            return ListType;
        }
    }
}

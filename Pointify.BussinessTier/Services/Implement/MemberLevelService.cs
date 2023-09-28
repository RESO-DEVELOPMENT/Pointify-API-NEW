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
using Pointify.DataTier.Models;

namespace Pointify.BussinessTier.Services.Implement
{
    public class MemberLevelService : BaseService<MemberLevelService>, IMemberLevelService
    {
        public MemberLevelService(IUnitOfWork<PromotionEngineContext> unitOfWork, ILogger<MemberLevelService> logger) : base(unitOfWork, logger)
        {
        }

        public async Task<MemberLevelResponse> CreateMemberLevel(MemberLevelRequest res)
        {
            MemberLevel newMemberLevel = new MemberLevel()
            {
                MemberLevelId = Guid.NewGuid(),
                BrandId = res.BrandId,
                Name = res.Name,
                DelFlg = true,
                UpdDate = res.UpdDate,
                InsDate = res.InsDate,
            };
            await _unitOfWork.GetRepository<MemberLevel>().InsertAsync(newMemberLevel);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return null;
            return new MemberLevelResponse(newMemberLevel.MemberLevelId, newMemberLevel.BrandId,
                newMemberLevel.Name, newMemberLevel.DelFlg,
                newMemberLevel.UpdDate, newMemberLevel.InsDate);
        }

        public async Task<bool> DeleteMemberLevel(Guid id)
        {
            MemberLevel type = await _unitOfWork.GetRepository<MemberLevel>().SingleOrDefaultAsync(
                               selector: x => x,
                                              predicate: x => x.MemberLevelId.Equals(id)
                                                         );
            if (type == null) return false;
            type.DelFlg = false;
            _unitOfWork.GetRepository<MemberLevel>().UpdateAsync(type);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return false;
            return true;
        }

        public async Task<IPaginate<MemberLevelResponse>> GetMemberLevel(int page, int size)
        {
            IPaginate<MemberLevelResponse> ListLevel =
            await _unitOfWork.GetRepository<MemberLevel>().GetPagingListAsync(
                selector: x => new MemberLevelResponse(x.MemberLevelId, x.BrandId, x.Name, x.DelFlg, x.UpdDate, x.InsDate),
                predicate: x => x.DelFlg == true,
                page: page,
                size: size
                );
            return ListLevel;
        }

        public async Task<MemberLevelResponse> GetMemberLevelById(Guid id)
        {
            MemberLevelResponse res = await _unitOfWork.GetRepository<MemberLevel>()
                .SingleOrDefaultAsync(selector: x => new MemberLevelResponse(
                    x.MemberLevelId, x.BrandId, x.Name, x.DelFlg, x.UpdDate, x.InsDate), predicate: x => (x.MemberLevelId.Equals(id)));
            return res;
        }
    }
}

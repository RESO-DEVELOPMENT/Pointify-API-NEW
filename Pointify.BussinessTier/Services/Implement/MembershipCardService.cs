using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using Pointify.BussinessTier.UnitOfWork.Interface;
using Pointify.BussinessTier.Util;
using Pointify.DataTier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Services.Implement
{
    public class MembershipCardService : BaseService<MembershipCardService>, IMembershipCardService
    {
        public MembershipCardService(IUnitOfWork<PromotionEngineContext> unitOfWork,
            ILogger<MembershipCardService> logger
        ) : base(unitOfWork, logger)
        {
        }

        public async Task<MembershipCardResponse> CreateMembershipCard(MembershipCardRequest res)
        {
            MembershipCard newMembershipCard = new MembershipCard()
            {
                Id = Guid.NewGuid(),
                MemberId = res.MemberId,
                MembershipCardCode = Common.makeCode(10),
                Active = true,
                CreatedTime = DateTime.Now,
                BrandId = res.BrandId,
                PhysicalCardCode = null,
                MembershipCardTypeId = res.MembershipCardTypeId
            };
            await _unitOfWork.GetRepository<MembershipCard>().InsertAsync(newMembershipCard);

            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return null;
            return new MembershipCardResponse(newMembershipCard.Id, newMembershipCard.MemberId,
                newMembershipCard.MembershipCardCode, newMembershipCard.Active, newMembershipCard.CreatedTime,
                newMembershipCard.BrandId, newMembershipCard.MembershipCardTypeId, newMembershipCard.PhysicalCardCode
            );
        }

        public async Task<bool> DeleteMembershipCard(Guid id)
        {
            MembershipCard member = await _unitOfWork.GetRepository<MembershipCard>().SingleOrDefaultAsync(
                selector: x => x,
                predicate: x => x.Id.Equals(id)
            );
            if (member == null) return false;
            member.Active = false;
            _unitOfWork.GetRepository<MembershipCard>().UpdateAsync(member);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return false;
            return true;
        }

        public async Task<MembershipCardResponse> GetMembershipCardById(Guid id)
        {
            MembershipCardResponse res = await _unitOfWork.GetRepository<MembershipCard>()
                .SingleOrDefaultAsync(selector: x => new MembershipCardResponse(
                    x.Id, x.MemberId, x.MembershipCardCode, x.Active, x.CreatedTime, x.BrandId, x.MembershipCardTypeId,
                    x.PhysicalCardCode), predicate: x => (x.Id.Equals(id)));
            return res;
        }

        public async Task<IPaginate<MembershipCardResponse>> GetMembershipCard(int page, int size)
        {
            IPaginate<MembershipCardResponse> ListMember =
                await _unitOfWork.GetRepository<MembershipCard>().GetPagingListAsync(
                    selector: x => new MembershipCardResponse(x.Id, x.MemberId, x.MembershipCardCode, x.Active,
                        x.CreatedTime, x.BrandId,
                        x.MembershipCardTypeId, x.PhysicalCardCode),
                    predicate: x => x.Active == true,
                    page: page,
                    size: size
                );
            return ListMember;
        }
    }
}
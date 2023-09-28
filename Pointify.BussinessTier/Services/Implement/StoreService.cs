using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using Pointify.BussinessTier.UnitOfWork.Interface;
using Pointify.DataTier.Models;

namespace Pointify.BussinessTier.Services.Implement
{
    public class StoreService : BaseService<StoreService>, IStoreService
    {
        public StoreService(IUnitOfWork<PromotionEngineContext> unitOfWork, ILogger<StoreService> logger
    ) : base(unitOfWork, logger)
        {
        }

        public async Task<ScanMemberResponse> ScanMembershipCard(string code)
        {
            ScanMemberResponse res = await _unitOfWork.GetRepository<MembershipCard>()
                .SingleOrDefaultAsync(
                                   selector: x => new ScanMemberResponse(x.Id, x.Member.PhoneNumber, x.Member.Email, x.Member.FullName),
                                   include: y => y.Include(x => x.Member),
                                                      predicate: x => (x.MembershipCardCode.Equals(code)
                                                                     ));
            return res;
        }
    }
}

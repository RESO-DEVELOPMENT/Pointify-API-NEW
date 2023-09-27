using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using Pointify.BussinessTier.UnitOfWork.Interface;
using Pointify.DataTier.Models;

namespace Pointify.BussinessTier.Services.Implement;

public class MemberProgramService : BaseService<MemberProgramService>, IMemberProgramService
{
    public MemberProgramService(IUnitOfWork<PromotionEngineContext> unitOfWork, ILogger<MemberProgramService> logger
    ) : base(unitOfWork, logger)
    {
    }


    public async Task<IPaginate<GetMembershipProgramResponse>> GetPrograms(string? searchProgramName, int page,
        int size)
    {
        searchProgramName = searchProgramName?.Trim().ToLower();
        IPaginate<GetMembershipProgramResponse> program = await _unitOfWork.GetRepository<MembershipProgram>()
            .GetPagingListAsync(
                selector: x => new GetMembershipProgramResponse(x.Id, x.BrandId, x.NameOfProgram, x.StartDay, x.EndDay,
                    x.TermAndConditions, x.Status
                ),
                predicate:
                string.IsNullOrEmpty(searchProgramName)
                    ? x => true
                    : x => x.NameOfProgram.ToLower().Contains(searchProgramName),
                page:
                page,
                size:
                size);
        return program;
    }
}
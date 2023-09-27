using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Response;

namespace Pointify.BussinessTier.Services.Interface;

public interface IMemberProgramService
{
    public Task<IPaginate<GetMembershipProgramResponse>> GetPrograms(string? searchProgramName, int page, int size);
}
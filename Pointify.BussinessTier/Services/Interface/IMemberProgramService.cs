using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;

namespace Pointify.BussinessTier.Services.Interface;

public interface IMemberProgramService
{
    public Task<IPaginate<GetMembershipProgramResponse>> GetPrograms(string? searchProgramName, int page, int size);
    public Task<GetMembershipProgramResponse> CreateProgram(GetMembershipProgramRequest newProgram);
    public Task<GetMembershipProgramResponse> UpdateProgram(Guid id, GetMembershipProgramRequest updateNewProgram);
    public Task<GetMembershipProgramResponse> GetProgramDetail(Guid id);

    public Task<GetMembershipProgramResponse> HideProgram(Guid id);
}
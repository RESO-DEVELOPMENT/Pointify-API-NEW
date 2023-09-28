using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
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
    public async Task<GetMembershipProgramResponse> CreateProgram(GetMembershipProgramRequest newProgram)
    {
        MembershipProgram program = new MembershipProgram()
        {
            Id = Guid.NewGuid(),
            BrandId = newProgram.BrandId,
            NameOfProgram = newProgram.NameOfProgram,
            StartDay = DateTime.Now,
            EndDay = DateTime.Now,
            DelFlg = false,
            TermAndConditions = newProgram.TermAndConditions,
            Status = "Success"
        };
        await _unitOfWork.GetRepository<MembershipProgram>().InsertAsync(program);
        bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
        if (!isSuccessful) return null;
        return new GetMembershipProgramResponse(program.Id, program.BrandId, program.NameOfProgram, program.StartDay, program.EndDay,
                                               program.TermAndConditions, program.Status);
    }

    public async Task<GetMembershipProgramResponse> UpdateProgram(Guid id,GetMembershipProgramRequest updateNewProgram)
    {
        MembershipProgram updateProgram = await _unitOfWork.GetRepository<MembershipProgram>().SingleOrDefaultAsync(predicate: x => x.Id.Equals(id));
        //if (updateProduct == null) 
        updateProgram.BrandId = updateNewProgram.BrandId;
        updateProgram.NameOfProgram = updateNewProgram.NameOfProgram;
        updateProgram.StartDay = updateNewProgram.StartDay;
        updateProgram.EndDay = updateNewProgram.EndDay;
        updateProgram.Status = updateNewProgram.Status;
        updateProgram.TermAndConditions = updateNewProgram.TermAndConditions;
        _unitOfWork.GetRepository<MembershipProgram>().UpdateAsync(updateProgram);
        await _unitOfWork.CommitAsync();
        return new GetMembershipProgramResponse(updateProgram.Id, updateProgram.BrandId, updateProgram.NameOfProgram, updateProgram.StartDay, updateProgram.EndDay,
                                               updateProgram.TermAndConditions, updateProgram.Status);
    }

    public async Task<GetMembershipProgramResponse> GetProgramDetail(Guid id)
    {
        GetMembershipProgramResponse program = await _unitOfWork.GetRepository<MembershipProgram>().SingleOrDefaultAsync(
            selector: x => new GetMembershipProgramResponse(x.Id, x.BrandId, x.NameOfProgram, x.StartDay, x.EndDay, x.TermAndConditions, x.Status),
            predicate: x => x.Id.Equals(id),
            include: x => x.Include(x => x.MembershipCardTypes)
            );
        return program;
    }

    public async Task<GetMembershipProgramResponse> HideProgram(Guid id)
    {
        MembershipProgram updateProgram = await _unitOfWork.GetRepository<MembershipProgram>().SingleOrDefaultAsync(predicate: x => x.Id.Equals(id));
        //if (updateProduct == null) 
        updateProgram.Id = updateProgram.Id;
        updateProgram.BrandId = updateProgram.BrandId;
        updateProgram.NameOfProgram = updateProgram.NameOfProgram;
        updateProgram.StartDay = updateProgram.StartDay;
        updateProgram.EndDay = updateProgram.EndDay;
        updateProgram.Status = updateProgram.Status;
        updateProgram.TermAndConditions = updateProgram.TermAndConditions;
        if(updateProgram.DelFlg == false)
        {
            updateProgram.DelFlg = true;
        }
        else
        {
            updateProgram.DelFlg = false;
        }
        _unitOfWork.GetRepository<MembershipProgram>().UpdateAsync(updateProgram);
        await _unitOfWork.CommitAsync();
        return new GetMembershipProgramResponse(updateProgram.Id, updateProgram.BrandId, updateProgram.NameOfProgram, updateProgram.StartDay, updateProgram.EndDay,
                                               updateProgram.TermAndConditions, updateProgram.Status);
    }
}
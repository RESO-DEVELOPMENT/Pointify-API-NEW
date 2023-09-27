using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using PointifyAPI.Constants;

namespace PointifyAPI.Controllers;

[ApiController]
public class ProgramController : BaseController<ProgramController>
{
    private readonly IMemberProgramService _programService;

    public ProgramController(ILogger<ProgramController> logger, IMemberProgramService programService) : base(logger)
    {
        _programService = programService;
    }

    [HttpGet(ApiEndPointConstant.Programs.ProgramsEndpoint)]
    [ProducesResponseType(typeof(IPaginate<GetMembershipProgramResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPrograms([FromQuery] string? name, [FromQuery] int page,
        [FromQuery] int size)
    {
        var programs = await _programService.GetPrograms(name, page, size);
        return Ok(programs);
    }

    [HttpPost(ApiEndPointConstant.Programs.ProgramsEndpoint)]
    [ProducesResponseType(typeof(IPaginate<GetMembershipProgramResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreatePrograms([FromBody]GetMembershipProgramRequest newProgram)
    {
        var programs = await _programService.CreateProgram(newProgram);
        return Ok(programs);
    }

    [HttpPatch(ApiEndPointConstant.Programs.ProgramsEndpoint)]
    [ProducesResponseType(typeof(IPaginate<GetMembershipProgramResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdatePrograms([FromQuery]Guid ProgramId, [FromBody] GetMembershipProgramRequest newProgram)
    {
        var programs = await _programService.UpdateProgram(ProgramId, newProgram);
        return Ok(programs);
    }

    [HttpGet(ApiEndPointConstant.Programs.ProgramEndpoint)]
    [ProducesResponseType(typeof(IPaginate<GetMembershipProgramResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProgramDetail(Guid id)
    {
        var programs = await _programService.GetProgramDetail(id);
        return Ok(programs);
    }
    [HttpPatch(ApiEndPointConstant.Programs.ProgramHideEndpoint)]
    [ProducesResponseType(typeof(IPaginate<GetMembershipProgramResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> HideProgram(Guid id)
    {
        var programs = await _programService.HideProgram(id);
        return Ok(programs);
    }
}
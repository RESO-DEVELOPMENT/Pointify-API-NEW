using Microsoft.AspNetCore.Mvc;
using Pointify.BussinessTier.Paginate;
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
}
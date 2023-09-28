using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request.MemberActionType;
using Pointify.BussinessTier.Payload.Request.WalletType;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Payload.Response.MemberActionType;
using Pointify.BussinessTier.Payload.Response.WallType;
using Pointify.BussinessTier.Services.Implement;
using Pointify.BussinessTier.Services.Interface;
using PointifyAPI.Constants;

namespace PointifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WallTypeController : BaseController<WallTypeController>
    {
        private readonly IWallTypeService _wallTypeService;

        public WallTypeController(ILogger<WallTypeController> logger, IWallTypeService wallTypeService) 
            : base(logger)
        {
            _wallTypeService = wallTypeService;
        }
        [HttpGet(ApiEndPointConstant.WallType.WallTypeEndpoint)]
        [ProducesResponseType(typeof(IPaginate<GetWallTypeResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPrograms([FromQuery] string? name, [FromQuery] int page,
        [FromQuery] int size)
        {
            var programs = await _wallTypeService.GetWallTypes(name, page, size);
            return Ok(programs);
        }

        [HttpPost(ApiEndPointConstant.WallType.WallTypeEndpoint)]
        [ProducesResponseType(typeof(IPaginate<GetWallTypeResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePrograms([FromBody] GetWallTypeRequest newProgram)
        {
            var programs = await _wallTypeService.CreateWallType(newProgram);
            return Ok(programs);
        }

        [HttpPatch(ApiEndPointConstant.WallType.WallTypeIdEndpoint)]
        [ProducesResponseType(typeof(IPaginate<GetWallTypeResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAction(Guid Id, [FromBody] GetWallTypeRequest newAction)
        {
            var programs = await _wallTypeService.UpdateWallType(Id, newAction);
            return Ok(programs);
        }
    }
}

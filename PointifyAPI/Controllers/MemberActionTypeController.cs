using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Request.MemberActionType;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Payload.Response.MemberActionType;
using Pointify.BussinessTier.Services.Interface;
using PointifyAPI.Constants;

namespace PointifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberActionTypeController : BaseController<MemberActionTypeController>
    {
        private readonly IMemberActionTypeService _memberActionTypeService;
        public MemberActionTypeController(ILogger<MemberActionTypeController> logger, IMemberActionTypeService memberActionTypeService) 
            : base(logger)
        {
            _memberActionTypeService = memberActionTypeService;
        }

        [HttpGet(ApiEndPointConstant.MemberActionType.ActionTypeEndpoint)]
        [ProducesResponseType(typeof(IPaginate<GetMembershipProgramResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPrograms([FromQuery] string? name, [FromQuery] int page,
        [FromQuery] int size)
        {
            var programs = await _memberActionTypeService.GetActionTypes(name, page, size);
            return Ok(programs);
        }

        [HttpPost(ApiEndPointConstant.MemberActionType.ActionTypeEndpoint)]
        [ProducesResponseType(typeof(IPaginate<GetMemberActionTypeResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePrograms([FromBody] GetMemberActionTypeRequest newProgram)
        {
            var programs = await _memberActionTypeService.CreateActionType(newProgram);
            return Ok(programs);
        }

        [HttpPatch(ApiEndPointConstant.MemberActionType.ActionTypeEndpoint)]
        [ProducesResponseType(typeof(IPaginate<GetMembershipProgramResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAction(Guid Id, [FromBody] GetMemberActionTypeRequest newAction)
        {
            var programs = await _memberActionTypeService.UpdateAction(Id, newAction);
            return Ok(programs);
        }
        [HttpGet(ApiEndPointConstant.MemberActionType.ActionTypeIdEndpoint)]
        [ProducesResponseType(typeof(IPaginate<GetMembershipProgramRequest>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProgramDetail(Guid id)
        {
            var programs = await _memberActionTypeService.GetActionDetail(id);
            return Ok(programs);
        }

        [HttpPatch(ApiEndPointConstant.MemberActionType.ActionHideEndpoint)]
        [ProducesResponseType(typeof(IPaginate<GetMembershipProgramResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> HideProgram(Guid id)
        {
            var programs = await _memberActionTypeService.HideAction(id);
            return Ok(programs);
        }
    }
}

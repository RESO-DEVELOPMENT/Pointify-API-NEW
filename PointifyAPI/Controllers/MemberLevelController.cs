using Microsoft.AspNetCore.Mvc;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Implement;
using Pointify.BussinessTier.Services.Interface;
using PointifyAPI.Constants;

namespace PointifyAPI.Controllers
{ 
    [ApiController]
    public class MemberLevelController : BaseController<MemberLevelController>
    {
    private readonly IMemberLevelService _memberLevelService;

    public MemberLevelController(ILogger<MemberLevelController> logger, IMemberLevelService memberLevelService) : base(logger)
    {
        _memberLevelService = memberLevelService;
    }
        [HttpPost(ApiEndPointConstant.MemberLevel.MemberLevelsEndpoint)]
        [ProducesResponseType(typeof(MemberLevelResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMemberLevel([FromBody] MemberLevelRequest res)
        {
            var memberLevel = await _memberLevelService.CreateMemberLevel(res);
            return Ok(memberLevel);
        }
        [HttpDelete(ApiEndPointConstant.MemberLevel.MemberLevelEndpoint)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteMemberLevel(Guid id)
        {
            var memberLevel = await _memberLevelService.DeleteMemberLevel(id);
            if (memberLevel == false)
            {
                return BadRequest(MessageConstant.MemberLevel.DeleteMemberLevelFailedMessage);
            }
            else
            {
                return Ok(MessageConstant.MemberLevel.MemberLevelDeletedMessage);
            }
        }
        [HttpGet(ApiEndPointConstant.MemberLevel.MemberLevelEndpoint)]
        [ProducesResponseType(typeof(MemberLevelResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMemberLevelById(Guid id)
        {
            var memberLevel = await _memberLevelService.GetMemberLevelById(id);
            if (memberLevel == null)
            {
                return BadRequest(MessageConstant.MemberLevel.MemberLevelNotFoundMessage);
            }
            else
            {
                return Ok(memberLevel);
            }
        }
        [HttpGet(ApiEndPointConstant.MemberLevel.MemberLevelsEndpoint)]
        [ProducesResponseType(typeof(IPaginate<MemberResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMember(int page, int size)
        {
            var memberLevel = await _memberLevelService.GetMemberLevel(page, size);
            return Ok(memberLevel);
        }
    }
}

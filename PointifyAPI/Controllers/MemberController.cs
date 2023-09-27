using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using PointifyAPI.Constants;

namespace PointifyAPI.Controllers
{
    [ApiController]
    public class MemberController : BaseController<MemberController>
    {
        private readonly IMemberService _memberService;

        public MemberController(ILogger<MemberController> logger, IMemberService memberService) : base(logger)
        {
            _memberService = memberService;
        }

        [HttpPost(ApiEndPointConstant.Member.MembersEndpoint)]
        [ProducesResponseType(typeof(MemberResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMember([FromBody] MemberRequest res)
        {
            var member = await _memberService.CreateMember(res);
            return Ok(member);
        }
        [HttpPatch(ApiEndPointConstant.Member.MemberEndpoint)]
        [ProducesResponseType(typeof(MemberResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateMember(Guid id, [FromBody] MemberRequest res)
        {
            var member = await _memberService.UpdateMember(id, res);
            return Ok(member);
        }
        [HttpDelete(ApiEndPointConstant.Member.MemberEndpoint)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteMember(Guid id)
        {
            var member = await _memberService.DeleteMember(id);
            if (member == false)
            {
                return BadRequest(MessageConstant.Member.DeleteMemberFailedMessage);
            }
            else
            {
                return Ok(MessageConstant.Member.MemberDeletedMessage);
            }
        }
        [HttpGet(ApiEndPointConstant.Member.MemberEndpoint)]
        [ProducesResponseType(typeof(MemberResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMemberById(Guid id)
        {
            var member = await _memberService.GetMemberById(id);
            if (member == null)
            {
                return BadRequest(MessageConstant.Member.MemberNotFoundMessage);
            }
            else
            {
                return Ok(member);
            }
        }
        [HttpGet(ApiEndPointConstant.Member.MembersEndpoint)]
        [ProducesResponseType(typeof(IPaginate<MemberResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMember(int page, int size)
        {
            var member = await _memberService.GetMember(page, size);
            return Ok(member);
        }
    }
}

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
    public class MembershipCardTypeController : BaseController<MembershipCardTypeController>
    {
        
        private readonly IMembershipCardTypeService _membershipCardTypeService;

        public MembershipCardTypeController(ILogger<MembershipCardTypeController> logger, IMembershipCardTypeService membershipCardTypeService) : base(logger)
        {
            _membershipCardTypeService = membershipCardTypeService;
        }

        [HttpPost(ApiEndPointConstant.MembershipCardType.MembershipCardTypesEndpoint)]
        [ProducesResponseType(typeof(MembershipCardTypeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMembershipCardType([FromBody] MembershipCardTypeRequest res)
        {
            var membershipCardType = await _membershipCardTypeService.CreateMembershipCardType(res);
            return Ok(membershipCardType);
        }

        [HttpGet(ApiEndPointConstant.MembershipCardType.MembershipCardTypeEndpoint)]
        [ProducesResponseType(typeof(MembershipCardTypeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMembershipCardTypeById(Guid id)
        {
            var membershipCardType = await _membershipCardTypeService.GetMembershipCardTypeById(id);
            if (membershipCardType == null)
            {
                return BadRequest(MessageConstant.MembershipCardType.MembershipCardTypeNotFoundMessage);
            }
            else
            {
                return Ok(membershipCardType);
            }
        }
        [HttpDelete(ApiEndPointConstant.MembershipCardType.MembershipCardTypeEndpoint)]
        [ProducesResponseType(typeof(MembershipCardTypeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteMembershipCardType([FromQuery] Guid id)
        {
            var membershipCardType = await _membershipCardTypeService.DeleteMembershipCardType(id);
            if (membershipCardType == false)
            {
                return BadRequest(MessageConstant.MembershipCardType.DeleteMembershipCardTypeFailedMessage);
            }
            else
            {
                return Ok(MessageConstant.MembershipCardType.MembershipCardTypeDeletedMessage);
            }
        }
        [HttpGet(ApiEndPointConstant.MembershipCardType.MembershipCardTypesEndpoint)]
        [ProducesResponseType(typeof(IPaginate<MembershipCardTypeResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMember(int page, int size)
        {
            var membershipCardType = await _membershipCardTypeService.GetMembershipCardType(page, size);
            return Ok(membershipCardType);
        }
    }
}

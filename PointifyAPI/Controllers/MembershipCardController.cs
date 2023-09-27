using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using PointifyAPI.Constants;

namespace PointifyAPI.Controllers
{
    [ApiController]
    public class MembershipCardController : BaseController<MembershipCardController>
    {
        private readonly IMembershipCardService _membershipCardService;

        public MembershipCardController(ILogger<MembershipCardController> logger, IMembershipCardService membershipCardService) : base(logger)
        {
            _membershipCardService = membershipCardService;
        }

        [HttpGet(ApiEndPointConstant.MembershipCard.MembershipCardEndpoint)]
        [ProducesResponseType(typeof(MembershipCardResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMembershipCardById(Guid id)
        {
            var membershipCard = await _membershipCardService.GetMembershipCardById(id);
            if (membershipCard == null)
            {
                return BadRequest(MessageConstant.MembershipCard.MembershipCardNotFoundMessage);
            }
            else
            {
                return Ok(membershipCard);
            }
        }

        [HttpDelete(ApiEndPointConstant.MembershipCard.MembershipCardEndpoint)]
        [ProducesResponseType(typeof(MembershipCardResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteMembershipCard([FromQuery] Guid id)
        {
            var membershipCard = await _membershipCardService.DeleteMembershipCard(id);
            if (membershipCard == false)
            {
                return BadRequest(MessageConstant.MembershipCard.DeleteMembershipCardFailedMessage);
            }
            else
            {
                return Ok(MessageConstant.MembershipCard.MembershipCardDeletedMessage);
            }
        }
        [HttpPost(ApiEndPointConstant.MembershipCard.MembershipCardsEndpoint)]
        [ProducesResponseType(typeof(MembershipCardResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMembershipCard([FromBody] MembershipCardRequest res)
        {
            var membershipCard = await _membershipCardService.CreateMembershipCard(res);
            return Ok(membershipCard);
        }
    }
}

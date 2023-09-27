using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using PointifyAPI.Constants;

namespace PointifyAPI.Controllers
{
    [ApiController]
    public class StoreController : BaseController<StoreController>
    {
        private readonly IStoreService _storeService;
        private readonly IMemberActionService _memberActionService;

        public StoreController(ILogger<StoreController> logger, IStoreService storeService,
            IMemberActionService memberActionService) : base(logger)
        {
            _storeService = storeService;
            _memberActionService = memberActionService;
        }

        [HttpGet(ApiEndPointConstant.Store.ScanMember)]
        [ProducesResponseType(typeof(ScanMemberResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ScanMember(string code)
        {
            var programs = await _storeService.ScanMembershipCard(code);

            if (programs == null)
            {
                return BadRequest(MessageConstant.Store.MemberShipCardCodeNotEsit);
            }

            return Ok(programs);
        }

        [HttpPost(ApiEndPointConstant.Store.MemberAction)]
        [ProducesResponseType(typeof(MemberActionRequest), StatusCodes.Status200OK)]
        public async Task<IActionResult> MemberAction(MemberActionRequest request)
        {
            var transaction = await _memberActionService.CreateMemberAction(request);

            if (transaction == null)
            {
                return BadRequest(MessageConstant.Store.ActionFail);
            }

            return Ok(transaction);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using PointifyAPI.Constants;

namespace PointifyAPI.Controllers
{

    [ApiController]
    public class StoreController : BaseController<StoreController>
    {
        private readonly IStoreService _storeService;

        public StoreController(ILogger<StoreController> logger, IStoreService storeService) : base(logger)
        {
            _storeService = storeService;
        }

        [HttpGet(ApiEndPointConstant.Store.ScanMember)]
        [ProducesResponseType(typeof(ScanMemberResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ScanMember(string code)
        {
            var programs = await _storeService.ScanMembershipCard(code);

            if(programs == null)
            {
                return BadRequest(MessageConstant.Store.MemberShipCardCodeNotEsit);
            }
            return Ok(programs);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.UnitOfWork.Interface;
using Pointify.DataTier.Models;


namespace Pointify.BussinessTier.Services
{
    public abstract class BaseService<T> where T : class
    {
        protected IUnitOfWork<PromotionEngineContext> _unitOfWork;
        protected ILogger<T> _logger;


        public BaseService(IUnitOfWork<PromotionEngineContext> unitOfWork, ILogger<T> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // protected string GetUsernameFromJwt()
        // {
        //     string username = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //     return username;
        // }
        //
        // protected string GetRoleFromJwt()
        // {
        //     string role = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.Role);
        //     return role;
        // }
        //
        //
        // protected string GetBrandIdFromJwt()
        // {
        //     return _httpContextAccessor?.HttpContext?.User?.FindFirstValue("brandId");
        // }
        //
        // protected string GetStoreIdFromJwt()
        // {
        //     return _httpContextAccessor?.HttpContext?.User?.FindFirstValue("storeId");
        // }
    }
}
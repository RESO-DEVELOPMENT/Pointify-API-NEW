using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using Pointify.BussinessTier.UnitOfWork.Interface;
using Pointify.DataTier.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Services.Implement
{
    public class MemberActionService : BaseService<MemberActionService>, IMemberActionService
    {
        public MemberActionService(IUnitOfWork<PromotionEngineContext> unitOfWork, ILogger<MemberActionService> logger
    ) : base(unitOfWork, logger)
        {
        }
    }
}

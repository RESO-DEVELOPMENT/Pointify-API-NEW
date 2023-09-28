using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request.WalletType;
using Pointify.BussinessTier.Payload.Response.WallType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Services.Interface
{
    public interface IWallTypeService
    {
        public  Task<IPaginate<GetWallTypeResponse>> GetWallTypes(string? searchProgramName, int page,
       int size);
        public Task<GetWallTypeResponse> CreateWallType(GetWallTypeRequest newProgram);
        public Task<GetWallTypeResponse> UpdateWallType(Guid id, GetWallTypeRequest updateNewProgram);
    }
}

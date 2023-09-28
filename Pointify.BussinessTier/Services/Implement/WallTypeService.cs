using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Request.WalletType;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Payload.Response.WallType;
using Pointify.BussinessTier.Services.Interface;
using Pointify.BussinessTier.UnitOfWork.Interface;
using Pointify.DataTier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Services.Implement
{
    public class WallTypeService : BaseService<WallTypeService>, IWallTypeService
    {
        public WallTypeService(IUnitOfWork<PromotionEngineContext> unitOfWork, ILogger<WallTypeService> logger)
        : base(unitOfWork, logger)
        {
        }

        public async Task<IPaginate<GetWallTypeResponse>> GetWallTypes(string? searchProgramName, int page,
       int size)
        {
            searchProgramName = searchProgramName?.Trim().ToLower();
            IPaginate<GetWallTypeResponse> program = await _unitOfWork.GetRepository<WalletType>()
                .GetPagingListAsync(
                    selector: x => new GetWallTypeResponse(x.Id, x.Name, x.MemberShipProgramId),
                    predicate:
                    string.IsNullOrEmpty(searchProgramName)
                        ? x => true
                        : x => x.Name.ToLower().Contains(searchProgramName),
                    include: x => x.Include(x => x.MemberShipProgram),
                    page:
                    page,
                    size:
                    size);
            return program;
        }

        public async Task<GetWallTypeResponse> CreateWallType(GetWallTypeRequest newProgram)
        {
            WalletType program = new WalletType()
            {   
                Id = Guid.NewGuid(),
                Name = newProgram.Name,
                MemberShipProgramId = newProgram.MemberShipProgramId,
                DelFlag = false
            };
            await _unitOfWork.GetRepository<WalletType>().InsertAsync(program);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return null;
            return new GetWallTypeResponse(program.Id, program.Name, program.MemberShipProgramId);
        }

        public async Task<GetWallTypeResponse> UpdateWallType(Guid id, GetWallTypeRequest updateNewProgram)
        {
            WalletType updateProgram = await _unitOfWork.GetRepository<WalletType>().SingleOrDefaultAsync(predicate: x => x.Id.Equals(id));
            //if (updateProduct == null) 
            updateProgram.Id = updateNewProgram.Id;
            updateNewProgram.Name = updateProgram.Name;
            updateNewProgram.MemberShipProgramId = updateProgram.MemberShipProgramId;
            updateNewProgram.DelFlag = false;
            _unitOfWork.GetRepository<WalletType>().UpdateAsync(updateProgram);
            await _unitOfWork.CommitAsync();
            return new GetWallTypeResponse(updateProgram.Id, updateProgram.Name, updateProgram.MemberShipProgramId);
        }

    }
}

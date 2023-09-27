using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.Paginate;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Payload.Response;
using Pointify.BussinessTier.Services.Interface;
using Pointify.BussinessTier.UnitOfWork.Interface;
using Pointify.DataTier.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Pointify.BussinessTier.Services.Implement
{
    public class MemberService : BaseService<MemberService>, IMemberService
    {
        public MemberService(IUnitOfWork<PromotionEngineContext> unitOfWork, ILogger<MemberService> logger
    ) : base(unitOfWork, logger)
        {
        }

        public async Task<MemberResponse> CreateMember(MemberRequest res)
        {
            Member newMember = new Member()
            {
                Id = Guid.NewGuid(),
                FullName = res.FullName,
                Email = res.Email,
                PhoneNumber = res.PhoneNumber,
                DelFlg = false,
                InsDate = DateTime.Now,
                UpdDate = DateTime.Now
            };
            await _unitOfWork.GetRepository<Member>().InsertAsync(newMember);

            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return null;
            return new MemberResponse(newMember.Id, newMember.PhoneNumber, newMember.Email, newMember.FullName, newMember.DelFlg, newMember.InsDate, newMember.UpdDate);
        }

        public async Task<MemberResponse> UpdateMember(Guid id, MemberRequest res)
        {
            Member member = await _unitOfWork.GetRepository<Member>().SingleOrDefaultAsync(
                               selector: x => x,
                                              predicate: x => x.Id.Equals(id)
                                                         );
            if (member == null) return null;
            member.FullName = res.FullName;
            member.Email = res.Email;
            member.PhoneNumber = res.PhoneNumber;
            member.UpdDate = DateTime.Now;
            _unitOfWork.GetRepository<Member>().UpdateAsync(member);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return null;
            return new MemberResponse(member.Id, member.PhoneNumber, member.Email, member.FullName, member.DelFlg, member.InsDate, member.UpdDate);
        }

        public async Task<bool> DeleteMember(Guid id)
        {
            Member member = await _unitOfWork.GetRepository<Member>().SingleOrDefaultAsync(
                               selector: x => x,
                                              predicate: x => x.Id.Equals(id)
                                                         );
            if (member == null) return false;
            member.DelFlg = true;
            _unitOfWork.GetRepository<Member>().UpdateAsync(member);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful) return false;
            return true;
        }

        public async Task<MemberResponse> GetMemberById(Guid id)
        {
            MemberResponse res = await _unitOfWork.GetRepository<Member>()
                .SingleOrDefaultAsync(
                                                  selector: x => new MemberResponse(x.Id, x.PhoneNumber, x.Email, x.FullName, x.DelFlg, x.InsDate, x.UpdDate),
                                                                                    predicate: x => (x.Id.Equals(id)
                                                                                                                                     ));
            return res;
        }
        public async Task<IPaginate<MemberResponse>> GetMember(int page, int size)
        {
            IPaginate<MemberResponse> ListMember =
            await _unitOfWork.GetRepository<Member>().GetPagingListAsync(
                selector: x => new MemberResponse(x.Id, x.PhoneNumber, x.Email, x.FullName, x.DelFlg, x.InsDate,
                    x.UpdDate),
                predicate: x => x.DelFlg == false,
                page: page,
                size: size
                );
            return ListMember;
        }
    }
}

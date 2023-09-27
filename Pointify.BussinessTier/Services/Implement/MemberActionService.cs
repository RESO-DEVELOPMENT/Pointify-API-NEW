using Microsoft.Extensions.Logging;
using Pointify.BussinessTier.Payload.Request;
using Pointify.BussinessTier.Services.Interface;
using Pointify.BussinessTier.UnitOfWork.Interface;
using Pointify.DataTier.Models;
using Microsoft.EntityFrameworkCore;
using static System.IO.IOException;

namespace Pointify.BussinessTier.Services.Implement
{
    public class MemberActionService : BaseService<MemberActionService>, IMemberActionService
    {
        public MemberActionService(IUnitOfWork<PromotionEngineContext> unitOfWork, ILogger<MemberActionService> logger
        ) : base(unitOfWork, logger)
        {
        }

        public async Task<MemberAction?> CreateMemberAction(MemberActionRequest request)
        {
            MembershipCard membershipCard = await _unitOfWork.GetRepository<MembershipCard>().SingleOrDefaultAsync(
                predicate:
                x => x.MembershipCardCode.Equals(request.MemberShipCardCode),
                include: y => y.Include(m => m.Member).Include(l => l.MemberShipCardLevel)
            );
            MemberActionType actionType = await _unitOfWork.GetRepository<MemberActionType>().SingleOrDefaultAsync(
                predicate: x => x.Id.Equals(request.MemberActionTypeId));

            MemberWallet wallet = await _unitOfWork.GetRepository<MemberWallet>().SingleOrDefaultAsync(
                predicate: x =>
                    x.MemberId.Equals(membershipCard.MemberId) && x.WalletTypeId.Equals(actionType.MemberWalletTypeId),
                include: w => w.Include(x => x.WalletType).ThenInclude(w => w.MemberActionTypes)
            );

            MemberAction memberAction = new MemberAction()
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Status = "PROCESSING",
                ActionValue = 0,
                MemberWalletId = wallet.Id,
                MemberShipCardId = membershipCard.Id,
                MemberActionTypeId = request.MemberActionTypeId,
            };
            await _unitOfWork.GetRepository<MemberAction>().InsertAsync(memberAction);
            switch (actionType.Code)
            {
                case "GET_POINT":
                    {
                        wallet.Balance += membershipCard.MemberShipCardLevel.PointRedeemRate ?? 0 * request.Amount;
                        wallet.BalanceHistory += membershipCard.MemberShipCardLevel.PointRedeemRate!
                                                 * request.Amount;
                        memberAction.ActionValue = membershipCard.MemberShipCardLevel.PointRedeemRate ?? 0 * request.Amount;
                        memberAction.Status = "COMPLETE";
                        memberAction.Description = "[Thành công] " + request.Description;
                        break;
                    }
                case "TOP_UP":
                    {
                        wallet.Balance += request.Amount;
                        wallet.BalanceHistory += request.Amount;
                        memberAction.ActionValue = request.Amount;
                        memberAction.Status = "COMPLETE";
                        memberAction.Description = "[Thành công] " + request.Description;
                        break;
                    }
                case "PAYMENT":
                    {
                        if (wallet.Balance < request.Amount)
                        {
                            memberAction.Status = "FAIL";
                            memberAction.Description = "[Thất bại] Số dư tài khoản không đủ";
                            break;
                        }

                        wallet.Balance -= request.Amount;
                        memberAction.ActionValue = request.Amount;
                        memberAction.Status = "COMPLETE";
                        memberAction.Description = "[Thành công] " + request.Description;
                        break;
                    }
            }

            if (memberAction.Status == "COMPLETE")
            {
                Transaction transaction = new Transaction()
                {
                    Id = Guid.NewGuid(),
                    BrandId = request.ApiKey,
                    InsDate = DateTime.Now,
                    UpdDate = DateTime.Now,
                    MemberActionId = memberAction.Id,
                    MemberWalletId = memberAction.MemberWalletId,
                    TransactionJson = memberAction.Description,
                    Amount = memberAction.ActionValue,
                    Currency = wallet.WalletType.Currency
                };

                await _unitOfWork.GetRepository<Transaction>().InsertAsync(transaction);
                var isSuccess = await _unitOfWork.CommitAsync();
                if (isSuccess < 1)
                {
                    memberAction.Status = "FAIL";
                    memberAction.Description = "[Thất bại] Giao dịch thất bại";
                }
            }

            _unitOfWork.GetRepository<MemberWallet>().UpdateAsync(wallet);
            _unitOfWork.GetRepository<MemberAction>().UpdateAsync(memberAction);
            var isSuccessful = await _unitOfWork.CommitAsync();
            return isSuccessful > 0 ? memberAction : null;
        }
    }
}
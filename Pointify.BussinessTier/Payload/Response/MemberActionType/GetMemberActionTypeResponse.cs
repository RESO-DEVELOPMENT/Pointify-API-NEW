namespace Pointify.BussinessTier.Payload.Response.MemberActionType
{
    public class GetMemberActionTypeResponse
    {

        public GetMemberActionTypeResponse(Guid id, string name, Guid? memberShipProgramId, Guid? memberWalletTypeId, string? code)
        {
            Id = id;
            Name = name;
            MemberShipProgramId = memberShipProgramId;
            MemberWalletTypeId = memberWalletTypeId;
            Code = code;
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool? DelFlag { get; set; }
        public Guid? MemberShipProgramId { get; set; }
        public Guid? MemberWalletTypeId { get; set; }
        public string? Code { get; set; }
    }
}

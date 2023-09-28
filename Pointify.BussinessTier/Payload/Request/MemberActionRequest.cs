namespace Pointify.BussinessTier.Payload.Request
{
    public class MemberActionRequest
    {
        public Guid ApiKey { get; set; }
        public string StoreCode { get; set; }
        public string MemberShipCardCode { get; set; }
        public int Amount { get; set; }
        public Guid MemberActionTypeId { get; set; }
        public string Description { get; set; }

        public MemberActionRequest(Guid apiKey, string storeCode, string memberShipCardCode, int amount,
            Guid actionTypeId, string description)
        {
            ApiKey = apiKey;
            this.StoreCode = storeCode;
            this.MemberShipCardCode = memberShipCardCode;
            this.Amount = amount;
            this.MemberActionTypeId = actionTypeId;
            this.Description = description;
        }
    }
}
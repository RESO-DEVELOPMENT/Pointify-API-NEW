using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Request
{
    public class MemberActionRequest
    {
        public Guid ApiKey { get; set; }
        public string StoreCode { get; set; }


        public string MemberShipCardCode { get; set; }
        public int Amount { get; set; }
        public Guid MemberActionTypeId { get; set; }

        public string? Description { get; set; }

        public MemberActionRequest(Guid apiKey, string storeCode, string memberShipCardCode, int amount,
            Guid memberActionTypeId, string? description)
        {
            ApiKey = apiKey;
            this.StoreCode = storeCode;
            this.MemberShipCardCode = memberShipCardCode;
            this.Amount = amount;
            this.MemberActionTypeId = memberActionTypeId;
            this.Description = description;
        }
    }
}
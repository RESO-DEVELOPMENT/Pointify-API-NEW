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
        public string storeCode { get; set; }
        public Guid memberId { get; set; }
        public int amount { get; set; }
        public string actionType { get; set; }

        public MemberActionRequest(Guid apiKey, string storeCode, Guid memberId, int amount, string actionType)
        {
            ApiKey = apiKey;
            this.storeCode = storeCode;
            this.memberId = memberId;
            this.amount = amount;
            this.actionType = actionType;
        }
    }
}

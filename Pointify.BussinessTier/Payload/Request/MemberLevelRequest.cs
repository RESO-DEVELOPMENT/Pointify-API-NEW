using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Request
{
    public class MemberLevelRequest
    {
        public Guid MemberLevelId { get; set; }
        public Guid BrandId { get; set; }
        public String Name { get; set; }
        public bool DelFlg { get; set; }
        public DateTime UpdDate { get; set; }
        public DateTime InsDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pointify.DataTier.Models;

namespace Pointify.BussinessTier.Payload.Response
{
    public class MemberLevelResponse
    {
        public Guid MemberLevelId { get; set; }
        public Guid BrandId { get; set; }
        public String Name { get; set; }
        public bool DelFlg { get; set; }
        public DateTime UpdDate { get; set; }
        public DateTime InsDate { get; set; }

        public MemberLevelResponse(Guid memberLevelId, Guid brandId, String name, bool delFlg, DateTime updDate, DateTime insDate)
        {
            MemberLevelId = memberLevelId;
            BrandId = brandId;
            Name = name;
            DelFlg = delFlg;
            UpdDate = updDate;
            InsDate = insDate;
        }


    }
}

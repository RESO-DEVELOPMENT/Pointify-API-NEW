using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Response
{
    public class MemberResponse
    {
        public Guid Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public bool? DelFlg { get; set; }
        public DateTime? InsDate { get; set; }
        public DateTime? UpdDate { get; set; }
        public Guid? MemberProgramId { get; set; }
        public Guid? CustomerId { get; set; }

        public MemberResponse(Guid id, string? phoneNumber, string? email, string? fullName, bool? delFlg, DateTime? insDate, DateTime? updDate)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            Email = email;
            FullName = fullName;
            DelFlg = delFlg;
            InsDate = insDate;
            UpdDate = updDate;
        }
    }
}

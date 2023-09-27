using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Response
{
    public class ScanMemberResponse
    {
        public ScanMemberResponse(Guid id, string? phoneNumber, string? email, string? fullName)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            Email = email;
            FullName = fullName;
        }

        public Guid Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
    }
}

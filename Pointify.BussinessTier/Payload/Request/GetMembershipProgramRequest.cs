using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pointify.BussinessTier.Payload.Request
{
    public class GetMembershipProgramRequest
    {
        public Guid Id { get; set; }
        //[Required(ErrorMessage = "BrandId must not be empty")]
        public Guid BrandId { get; set; }
        public string? NameOfProgram { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? EndDay { get; set; }
        public string? TermAndConditions { get; set; }
        public string? Status { get; set; }
    }
}

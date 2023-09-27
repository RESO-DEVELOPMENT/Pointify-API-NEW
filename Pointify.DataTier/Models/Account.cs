using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Account
    {
        public string Username { get; set; } = null!;
        public int RoleId { get; set; }
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public string? ImgUrl { get; set; }
        public bool IsActive { get; set; }
        public Guid? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Role Role { get; set; } = null!;
    }
}

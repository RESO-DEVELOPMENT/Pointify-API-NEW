using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class MemberLevel
    {
        public MemberLevel()
        {
            MemberLevelMappings = new HashSet<MemberLevelMapping>();
        }

        public Guid MemberLevelId { get; set; }
        public Guid BrandId { get; set; }
        public string Name { get; set; } = null!;
        public bool DelFlg { get; set; }
        public DateTime UpdDate { get; set; }
        public DateTime InsDate { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<MemberLevelMapping> MemberLevelMappings { get; set; }
    }
}

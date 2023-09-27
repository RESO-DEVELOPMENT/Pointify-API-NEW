using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Device
    {
        public Guid DeviceId { get; set; }
        public Guid StoreId { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }

        public virtual Store Store { get; set; } = null!;
    }
}

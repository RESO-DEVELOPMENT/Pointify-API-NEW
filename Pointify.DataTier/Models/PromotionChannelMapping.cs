using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class PromotionChannelMapping
    {
        public Guid PromotionChannelId { get; set; }
        public Guid PromotionId { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }

        public virtual Channel Channel { get; set; } = null!;
        public virtual Promotion Promotion { get; set; } = null!;
    }
}

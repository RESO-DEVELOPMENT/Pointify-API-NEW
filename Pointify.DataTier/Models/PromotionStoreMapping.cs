﻿using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class PromotionStoreMapping
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Guid PromotionId { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }

        public virtual Promotion Promotion { get; set; } = null!;
        public virtual Store Store { get; set; } = null!;
    }
}

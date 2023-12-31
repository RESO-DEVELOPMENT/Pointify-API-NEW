﻿using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class ActionProductMapping
    {
        public Guid Id { get; set; }
        public Guid ActionId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public int? Quantity { get; set; }

        public virtual Action Action { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}

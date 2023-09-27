using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class GameMaster
    {
        public GameMaster()
        {
            GameCampaigns = new HashSet<GameCampaign>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int MinItem { get; set; }
        public int MaxItem { get; set; }
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }

        public virtual ICollection<GameCampaign> GameCampaigns { get; set; }
    }
}

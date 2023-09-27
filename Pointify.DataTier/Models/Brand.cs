using System;
using System.Collections.Generic;

namespace Pointify.DataTier.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Accounts = new HashSet<Account>();
            Actions = new HashSet<Action>();
            Channels = new HashSet<Channel>();
            ConditionRules = new HashSet<ConditionRule>();
            Customers = new HashSet<Customer>();
            GameCampaigns = new HashSet<GameCampaign>();
            Gifts = new HashSet<Gift>();
            MemberLevels = new HashSet<MemberLevel>();
            MembershipPrograms = new HashSet<MembershipProgram>();
            ProductCategories = new HashSet<ProductCategory>();
            Promotions = new HashSet<Promotion>();
            Stores = new HashSet<Store>();
            Transactions = new HashSet<Transaction>();
            VoucherGroups = new HashSet<VoucherGroup>();
        }

        public Guid BrandId { get; set; }
        public string BrandCode { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public string BrandName { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? Description { get; set; }
        public string? Address { get; set; }
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public string? BrandEmail { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<Channel> Channels { get; set; }
        public virtual ICollection<ConditionRule> ConditionRules { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<GameCampaign> GameCampaigns { get; set; }
        public virtual ICollection<Gift> Gifts { get; set; }
        public virtual ICollection<MemberLevel> MemberLevels { get; set; }
        public virtual ICollection<MembershipProgram> MembershipPrograms { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<VoucherGroup> VoucherGroups { get; set; }
    }
}

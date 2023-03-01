using System.Collections.Generic;

#nullable disable

namespace bankingMVCApp_EF.Models.EF
{
    public partial class BranchInfo
    {
        public BranchInfo()
        {
            AccountsInfos = new HashSet<AccountsInfo>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchCity { get; set; }

        public virtual ICollection<AccountsInfo> AccountsInfos { get; set; }
    }
}

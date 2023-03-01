#nullable disable

namespace bankingMVCApp_EF.Models.EF
{
    public partial class TransactionInfo
    {
        public int TrId { get; set; }
        public int? TrFromAccount { get; set; }
        public int? TrToAccount { get; set; }
        public int? TrAmount { get; set; }
    }
}

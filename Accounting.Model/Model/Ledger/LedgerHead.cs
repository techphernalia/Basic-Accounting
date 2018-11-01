namespace Accounting.Model.Model.Ledger
{
    public class LedgerHead
    {
        public int LedgerHeadId { get; set; }
        public string LedgerHeadName { get; set; }
        public string LedgerHeadDescription { get; set; }
        public LedgerType ParentLedgerType { get; set; }
        public LedgerHead ParentLedgerHead { get; set; }
        public bool AffectsGrossPnL { get; set; }
    }
}

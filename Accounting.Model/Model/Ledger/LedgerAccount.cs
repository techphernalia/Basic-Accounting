namespace Accounting.Model.Model.Ledger
{
    public class LedgerAccount
    {
        public int LedgerAccountId { get; set; }
        public string LedgerAccountName { get; set; }
        public LedgerHead ParentLedgerHead { get; set; }
        public double OpeningBalance { get; set; }
        public bool AffectsInventory { get; set; }
    }
}

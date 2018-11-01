namespace Accounting.Model.Model.Ledger
{
    public class LedgerType
    {
        public int LedgerTypeId { get; set; }
        public string LedgerTypeName { get; set; }
        public bool CanParticipateInPnL { get; set; }
    }
}

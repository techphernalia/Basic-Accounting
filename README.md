# Basic-Accounting


# Accounting.Models
Contains Model objects of our project

Rather than keeping all Models in root folder/Namespace, we will categorize them on the basis of their relation.

Models related with managing of accounts will be grouped and placed inside Ledger folder

* **Model**
 * **Ledger** : Ledger contains Models required for Accounts Management
   * **LedgerType**
     * *LedgerTypeId* : Unique Id of Ledger Type
     * *LedgerTypeName* : Name of Ledger Type, e.g. Asset, Liability, Revenue, Expense
     * *CanParticipateInPnL* : Weather accounts in said LedgerType participate in calculation of Profit and Loss
   * **LedgerHead**
     * *LedgerHeadId* : Unique Id of Ledger Head
     * *LedgerHeadName* : Name of Ledger Head, e.g. Direct Expense, Indirect Expense
     * *LedgerHeadDescription* : Short Description of Ledger Head
     * *ParentLedgerType* : Ledger Type for current Ledger Head
     * *ParentLedgerHead* : Parent Head of current Ledger Head
     * *AffectsGrossPnL* : Weather accounts in current head affects Gross Profit and Loss, applicable only if CanParticipateInPnL for ParentLedgerType is true
  * **LedgerAccount**
     * *LedgerAccountId* : Unique Id of Ledger Account
     * *LedgerAccountName* : Name of Ledger Account
     * *ParentLedgerHead* : Head under which current account lies
     * *OpeningBalance* : Opening Balance of account
     * *AffectsInventory* : Weather this account affects Inventory items

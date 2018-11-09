select * from LedgerTypes
select * from LedgerHeads
select * from LedgerAccounts
select * from TransactionSummaries
select * from TransactionAccountDetails


/*

insert into LedgerTypes(LedgerTypeName,CanParticipateInPnL) values
('Assets',0),
('Liabilities',0),
('Revenue',1),
('Expense',1)

insert into LedgerHeads(LedgerHeadName,LedgerHeadDescription,AffectsGrossPnL,ParentLedgerHeadId,ParentLedgerTypeId) values
('Cash A/c','',0,0,1),
('Accounts Receivable','',0,0,1),
('Inventory','',0,0,1),
('Supplies','',0,0,1),
('Prepaid Insurance','',0,0,1),
('Current Assets','',0,0,1),
('Fixed Assets','',0,0,1),
('Investments','',0,0,1),
('Accounts Payable','',0,0,2),
('Capital A/c','',0,0,2),
('Current Liabilities','',0,0,2),
('Loans (Liabilities)','',0,0,2),
('Direct Income','',1,0,3),
('Indirect Income','',0,0,3),
('Sales A/c','',1,0,3),
('Direct Expense','',1,0,4),
('Indirect Expense','',0,0,4),
('Purchase A/c','',1,0,4)

insert into LedgerAccounts(LedgerAccountName,ParentLedgerHeadId,OpeningBalance,AffectsInventory) values
('Cash In Hand',1,0,0),
('SBI Mutual Fund',8,0,0),

*/
Running this project

* Download Repository
* Open **Accounting.UI.sln** in Visual Studio
* Build the Project
* Run **Accounting.UI** project
* It will create empty database
* Stop project
* Open **SQL Server Object Explorer** (from **View** Menu)
* Feed sample Data from **Accounting.Model->DBQueries->00x.xxx.sql** files
* Re Run the project

Available URLs:

* List Items
 * /LedgerType
 * /LedgerHead
 * /LedgerAccount
* Create Items
 * /LedgerType/Create
 * /LedgerHead/Create
 * /LedgerAccount/Create
 * /Transaction/Create

**Please note ReadMe file is old and is not latest (Documentation in Progress)**

# Basic-Accounting

# Accounting.Models
Contains Model objects of our project

Rather than keeping all Models in root folder/Namespace, we will categorize them on the basis of their relation.

Models related with managing of accounts will be grouped and placed inside Ledger folder

* **Model**
  * **Ledger** : Ledger contains Models required for Accounts Management. Diferent Accounts(LedgerAccount) are grouped under LedgerHead which belongs to another LedgerHead or LedgerType. Each account ultimately comes under one of the LedgerType.
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

**Nuget Packages** Nuget Packages used in project

* Install-Package EntityFramework -projectname Accounting.Model
* Install-Package EntityFramework -projectname Accounting.UI
* Install-Package -version 3.0.0 bootstrap -projectname Accounting.UI
* Install-Package Ninject -version 3.0.1.10 -projectname Accounting.UI
* Install-Package Ninject.Web.Common -version 3.0.0.7 -projectname Accounting.UI
* Install-Package Ninject.MVC3 -Version 3.0.0.6 -projectname Accounting.UI
* Install-Package Microsoft.Aspnet.Mvc -version 5.0.0 -projectname Accounting.Model

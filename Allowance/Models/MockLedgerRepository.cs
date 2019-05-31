using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allowance.Models
{
    public class MockLedgerRepository : ILedgerRespository
    {
        private List<LedgerTransaction> _ledgerTransactions;

        public MockLedgerRepository()
        {
            if (_ledgerTransactions == null)
            {
                InitializeLedgerTransactions();
            }
        }

        private void InitializeLedgerTransactions()
        {
            _ledgerTransactions = new List<LedgerTransaction>()
            {
                new LedgerTransaction{TransactionId=1,PersonId=1,TAmount=10,TDescription="Initial Balance",TDate=Convert.ToDateTime("2019-05-31 12:00"),TransactionHash="InitialBalance"},
                new LedgerTransaction{TransactionId=2,PersonId=1,TAmount=20,TDescription="Monthly Allowance",TDate=Convert.ToDateTime("2019-06-01 00:00"),TransactionHash="BlockchainHashGoesHere"},
                new LedgerTransaction{TransactionId=3,PersonId=1,TAmount=20,TDescription="Mowed Neighbour's Lawn",TDate=Convert.ToDateTime("2019-06-08 00:00"),TransactionHash="BlockchainHashGoesHere"},
                new LedgerTransaction{TransactionId=5,PersonId=1,TAmount=20,TDescription="Monthly Allowance",TDate=Convert.ToDateTime("2019-07-01 00:00"),TransactionHash="BlockchainHashGoesHere"},
                new LedgerTransaction{TransactionId=4,PersonId=1,TAmount=-50,TDescription="Video Game Purchase",TDate=Convert.ToDateTime("2019-06-12 00:00"),TransactionHash="BlockchainHashGoesHere"},
            };
        }

        private void CalculateLineBalance()
        {
            decimal newBalance = 0;
            foreach (var item in _ledgerTransactions.OrderBy(s => s.TransactionId))
            {
                if (item.TransactionHash == "InitialBalance")
                {
                    newBalance = item.TAmount;
                }
                else
                {
                    newBalance += item.TAmount;
                }

                item.TBalance = newBalance;
            }
        }
        public IEnumerable<LedgerTransaction> GetAllLedgerTransactions(int personID)
        {
            CalculateLineBalance();
            return _ledgerTransactions.OrderBy(s => s.TransactionId);
        }
    }
}

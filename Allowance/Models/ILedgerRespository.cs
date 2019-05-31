using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allowance.Models
{
    public interface ILedgerRespository
    {
        IEnumerable<LedgerTransaction> GetAllLedgerTransactions(int personID);
    }
}

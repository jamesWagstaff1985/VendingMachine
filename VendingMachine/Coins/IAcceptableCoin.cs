using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CoinManager
{
    interface IAcceptableCoin
    {
        string CoinName { get; set; }
        int CoinValueInCents { get; set; }
    }
}

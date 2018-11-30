using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CoinManager
{
    class AcceptableCoin : IAcceptableCoin
    {
        public string CoinName { get; set; }
        public int CoinValueInCents { get; set; }

        public AcceptableCoin(string coinName, int coinValueInCents)
        {
            CoinName = coinName;
            CoinValueInCents = coinValueInCents;
        }
    }
}

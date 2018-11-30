using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.CoinManager;
using VendingMachine.ProductManager;

namespace VendingMachine.MachineManager
{
    class MachineContents : IMachine
    {
        public List<Product> ProductsInMachine { get; set; }
        public List<Coin> CoinsInMachine { get; set; }
        public List<AcceptableCoin> AcceptableCoins { get; set; }
    }
}

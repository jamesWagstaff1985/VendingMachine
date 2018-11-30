using System.Collections.Generic;
using VendingMachine.CoinManager;
using VendingMachine.ProductManager;

namespace VendingMachine.MachineManager
{
    interface IMachine
    {
        List<AcceptableCoin> AcceptableCoins { get; set; }
        List<Coin> CoinsInMachine { get; set; }
        List<Product> ProductsInMachine { get; set; }
    }
}
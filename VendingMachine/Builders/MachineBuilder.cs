using System.Collections.Generic;
using VendingMachine.CoinManager;
using VendingMachine.MachineManager;
using VendingMachine.ProductManager;

namespace VendingMachine.Builders
{
    class MachineBuilder
    {
        private List<Product> _productsInMachine;
        private List<Coin> _coinsInMachine;
        private List<AcceptableCoin> _acceptableCoins;

        public MachineBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _coinsInMachine = new List<Coin>();
            _acceptableCoins = new List<AcceptableCoin>()
            {
                 new AcceptableCoin("5c", 5),
                 new AcceptableCoin("10c", 10),
                 new AcceptableCoin("20c", 20),
                 new AcceptableCoin("50c", 50),
                 new AcceptableCoin("$1", 100)
            };
        }

        public MachineBuilder WithProducts(List<Product> products)
        {
            _productsInMachine = products;
            return this;
        }

        public MachineBuilder WithCoins(List<Coin> coins)
        {
            _coinsInMachine = coins;
            return this;
        }

        public MachineBuilder ExtraCoinsToAccept(List<AcceptableCoin> acceptableCoins)
        {
            foreach(var acceptableCoin in acceptableCoins)
                _acceptableCoins.Add(acceptableCoin);
            return this;
        }

        public MachineContents Build()
        {
            MachineContents machineContents = new MachineContents
            {
                ProductsInMachine = _productsInMachine,
                CoinsInMachine = _coinsInMachine,
                AcceptableCoins = _acceptableCoins
            };

            return machineContents;
        }
    }
}

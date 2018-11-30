using System.Collections.Generic;
using VendingMachine.Builders;
using VendingMachine.CoinManager;
using VendingMachine.DisplayManager;
using VendingMachine.MachineManager;
using VendingMachine.ProductManager;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            MachineContents machine1 = new MachineBuilder()
                 .WithCoins(new List<Coin>
                    {
                        new Coin("5c", 10),
                        new Coin("10c", 10),
                        new Coin("20c", 10),
                        new Coin("50c", 10),
                        new Coin("$1", 10)
                    })
                    .WithProducts(new List<Product>
                    {
                        new Product("Snickers", 50, 1),
                        new Product("Ruffles", 50, 10),
                        new Product("Pinguinos", 127, 10)
                    })
                 .ExtraCoinsToAccept(new List<AcceptableCoin>
                    {
                        new AcceptableCoin("Super", 5000)
                    })
                .Build();

            MachineController controller1 = new MachineController(machine1, new MachineDisplayer());
        }
    }
}

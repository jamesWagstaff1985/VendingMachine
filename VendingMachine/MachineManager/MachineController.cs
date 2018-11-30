using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VendingMachine.CoinManager;
using VendingMachine.DisplayManager;
using VendingMachine.ProductManager;

namespace VendingMachine.MachineManager
{
    class MachineController
    {
        private MachineContents _machineContents;
        private MachineDisplayer _machineDisplayer;

        public MachineController(MachineContents machineContents, MachineDisplayer machineDisplayer)
        {
            _machineContents = machineContents;
            _machineDisplayer = machineDisplayer;

            Init();
        }

        public void Init()
        {
            Console.Clear();

            _machineDisplayer.DisplayMachineToUser(_machineContents);

            string[] CoinsEntered = PromptCoins();

            if(CoinsEntered.Length > 0 && !string.IsNullOrWhiteSpace(CoinsEntered[0]))
            {
                (List<Coin> goodCoins, List<string> badCoins) = Helpers.SeparateGoodAndBadCoins(CoinsEntered, _machineContents.AcceptableCoins);

            ReturnCoins(badCoins);

            int TotalEntered = Helpers.TotalCoins(goodCoins, _machineContents.AcceptableCoins);

            Console.WriteLine("Amount Entered {0}", Helpers.FormatPrice(TotalEntered));

            Console.WriteLine("Select a product, eg. Snickers or press c to cancel");

            string RequestedProduct = Console.ReadLine();

            ProcessOrder(goodCoins, TotalEntered, RequestedProduct);
            }
            else
            {
                AddDelay();
                Init();
            }
        }

        private void ProcessOrder(List<Coin> goodCoins, int totalEntered, string requestedProduct)
        {
            if (requestedProduct == "c")
            {
                ReturnCoins(Helpers.ConvertCoinsToString(goodCoins));
                AddDelay();
                Init();
            }
            else
            {
                if (Helpers.ProductIsValid(requestedProduct, _machineContents.ProductsInMachine) &&
                    _machineContents.ProductsInMachine.Any(p => p.ProductName == requestedProduct &&
                    p.ProductPriceInCents <= totalEntered))
                {
                    int productPrice = _machineContents.ProductsInMachine.Single(p => p.ProductName == requestedProduct).ProductPriceInCents;

                    AddCoins.AddCoinsToSystem(goodCoins, _machineContents.CoinsInMachine);

                    List<string> Change = ChangeCalculator.CalculateChange(totalEntered, productPrice, _machineContents);

                    RemoveProduct.RemoveProductFromSystem(requestedProduct, _machineContents);

                    DeliverProduct(requestedProduct);

                    ReturnCoins(Change);

                    AddDelay();

                    Init();
                }
                else
                {
                    Console.WriteLine("Product Not available, press c to cancel or enter another product");
                    string newRequest = Console.ReadLine();

                    if(newRequest == "c")
                    {
                        ReturnCoins(Helpers.ConvertCoinsToString(goodCoins));
                        AddDelay();
                        Init();
                    }
                    else
                    {
                        ProcessOrder(goodCoins, totalEntered, requestedProduct);
                    }
                }
            }
        }


        private void DeliverProduct(string requestedProduct)
        {
            Console.WriteLine("Enjoy your {0}", requestedProduct);
        }

        private string[] PromptCoins()
        {
            string CoinsEnteredByUser = Console.ReadLine().Trim();

            return Helpers.ConvertToArray(CoinsEnteredByUser);
        }

        private void ReturnCoins(List<string> Coins)
        {
            if (Coins.Count > 0)
            {
                Console.Write("Returned Coins: ");
                Coins.ForEach(c => Console.Write("{0} ", c));
                Console.WriteLine();
            }
        }

        private void AddDelay()
        {
            Thread.Sleep(2000);
        }
    }
}

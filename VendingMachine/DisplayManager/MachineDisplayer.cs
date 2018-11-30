using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.CoinManager;
using VendingMachine.MachineManager;
using VendingMachine.ProductManager;
using VendingMachine.StylingHelpers;

namespace VendingMachine.DisplayManager
{
    class MachineDisplayer
    {
        public void DisplayMachineToUser(MachineContents machineContents)
        {
            if(machineContents.ProductsInMachine != null)
            {
                DisplayTitle();
                DisplayProducts(machineContents.ProductsInMachine);
                DisplayAcceptedCoinsAsString(machineContents.AcceptableCoins);
                DisplayInstructions();
            }
            else
            {
                Console.WriteLine("nayyyy");
            }
        }

        private void DisplayTitle()
        {
            ConsoleStyling.HorizontalLine();
            ConsoleStyling.VerticalSpace();
            ConsoleStyling.CenteredText("Vending Machine");
            ConsoleStyling.VerticalSpace();
            ConsoleStyling.HorizontalLine();
        }

        private void DisplayProducts(List<Product> productsInMachine)
        {
            foreach(var product in productsInMachine)
            {
                string priceToDisplay = Helpers.FormatPrice(product.ProductPriceInCents);
                ConsoleStyling.CenteredText(string.Format("{0}  {1}", product.ProductName, priceToDisplay));
            }
            ConsoleStyling.HorizontalLine();
        }

        private void DisplayAcceptedCoinsAsString(List<AcceptableCoin> acceptableCoins)
        {
            StringBuilder AcceptedCoinsString = new StringBuilder();
            foreach (var acceptableCoin in acceptableCoins)
                AcceptedCoinsString.Append($"{acceptableCoin.CoinName}  ");
            Console.WriteLine("Accepted Coins: {0}", AcceptedCoinsString.ToString());
        }

        private void DisplayInstructions()
        {
            Console.WriteLine("Please enter coin(s) eg. 10c 50c $1");
        }

    }
}

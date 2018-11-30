using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.CoinManager;
using VendingMachine.ProductManager;

namespace VendingMachine
{
    class Helpers
    {
        public static string[] ConvertToArray(string input)
        {
            string[] InputArray = input.Split(' ');
            return InputArray;
        }

        public static (List<Coin> goodCoins, List<string>badCoins) SeparateGoodAndBadCoins(string[] coinsToCheck, List<AcceptableCoin> acceptableCoins)
        {
            List<Coin> goodCoins = new List<Coin>();
            List<string> badCoins = new List<string>();

            foreach (string coin in coinsToCheck)
            {
                if (acceptableCoins.Any(c => c.CoinName == coin))
                    goodCoins.Add(new Coin(coin, 1));
                else
                    badCoins.Add(coin);
            }

            return (goodCoins, badCoins);
        }

        public static string ConvertToString(dynamic badCoins)
        {
            StringBuilder ConvertedToString = new StringBuilder();
            foreach(var coin in badCoins)
                ConvertedToString.Append(coin);

            return ConvertedToString.ToString();
        }

        internal static bool ProductIsValid(string requestedProduct, List<Product> productsInMachine)
        {
            return productsInMachine.Any(p => p.ProductName == requestedProduct);
        }

        internal static List<string> ConvertCoinsToString(List<Coin> goodCoins)
        {
            List<string> toReturn = new List<string>();

            goodCoins.ForEach(c => toReturn.Add(c.CoinName + " "));

            return toReturn;
        }

        internal static int TotalCoins(List<Coin> goodCoins, List<AcceptableCoin> acceptableCoins)
        {
            int total = 0;

            foreach (var coin in goodCoins)
            {
                AcceptableCoin amountToAdd = acceptableCoins.Single(c => c.CoinName == coin.CoinName);
                total += amountToAdd.CoinValueInCents;
            }
            return total;
        }

        internal static string FormatPrice(int productPriceInCents)
        {
            if (productPriceInCents < 100)
                return $"{productPriceInCents}\u00A2";
            else if (productPriceInCents == 100)
                return $"${productPriceInCents / 100}";
            else
                return $"${productPriceInCents/100}.{productPriceInCents % 100}\u00A2";

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.MachineManager;

namespace VendingMachine.CoinManager
{
    class ChangeCalculator
    {
        internal static List<string> CalculateChange(int totalEntered, int productPrice, MachineContents machineContents)
        {
            List<string> Change = new List<string>();

            int toReturn = totalEntered - productPrice;

            var OrderedList = machineContents.AcceptableCoins.OrderByDescending(v => v.CoinValueInCents).ToList();

            while(toReturn > 0 &&
                machineContents.AcceptableCoins.Any(c => c.CoinValueInCents <= toReturn))
            {
                try
                {
                    AcceptableCoin toDeduce = OrderedList.First(c => c.CoinValueInCents <= toReturn &&
                                                                        machineContents.CoinsInMachine.Any(co => co.CoinName == c.CoinName));
                    Change.Add(toDeduce.CoinName);
                    RemoveCoins.RemoveCoin(machineContents.CoinsInMachine.First(c => c.CoinName == toDeduce.CoinName),
                                            machineContents);
                    toReturn -= toDeduce.CoinValueInCents;
                }
                catch (Exception)
                {
                    break;
                }
            }
            if (toReturn > 0)
                Change.Add($"Insufficient Coins in machine, you are owed {Helpers.FormatPrice(toReturn)}");
            return Change;
        }
    }
}

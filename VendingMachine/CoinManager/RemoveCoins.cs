using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.MachineManager;

namespace VendingMachine.CoinManager
{
    class RemoveCoins
    {
        public static void RemoveAllCoins(List<Coin> coinsToRemove, MachineContents machineContents)
        {
            foreach (Coin coin in coinsToRemove)
                RemoveCoin(coin, machineContents);
        }

        public static void RemoveCoin(Coin coin, MachineContents machineContents)
        {
            if(machineContents.CoinsInMachine.Any(c => c.CoinName == coin.CoinName && c.CoinQuantity > 1))
            {
                machineContents.CoinsInMachine
                .Where(c => c.CoinName == coin.CoinName && c.CoinQuantity > 1)
                .Select(c => c.CoinQuantity--)
                .ToList();
            }
            else
            {
                machineContents.CoinsInMachine.RemoveAll(c => c.CoinName == coin.CoinName);
            }
        }
    }
}

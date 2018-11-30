using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.CoinManager
{
    class AddCoins
    {
        public static void AddCoinsToSystem(List<Coin> coinsToAdd, List<Coin> coinsInMachine)
        {
            for(int i = 0; i < coinsToAdd.Count; i++)
            {
                if (coinsInMachine.Any(c => c.CoinName == coinsToAdd[i].CoinName))
                {
                    coinsInMachine.Where(c => c.CoinName == coinsToAdd[i].CoinName).Select(u => u.CoinQuantity ++).ToList();
                    coinsToAdd.Remove(coinsToAdd[i]);
                    i = -1;
                }
            }
            if (coinsToAdd.Count > 0)
                coinsToAdd.ForEach(c => coinsInMachine.Add(c));
        }
    }
}

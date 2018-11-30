namespace VendingMachine.CoinManager
{
    class Coin : ICoin
    {
        public string CoinName { get; set; }
        public int CoinQuantity { get; set; }

        public Coin(string coinName, int coinQuantity)
        {
            CoinName = coinName;
            CoinQuantity = coinQuantity;
        }
    }
}

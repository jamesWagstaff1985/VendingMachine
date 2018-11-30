namespace VendingMachine.CoinManager
{
    interface ICoin
    {
        string CoinName { get; set; }
        int CoinQuantity { get; set; }
    }
}
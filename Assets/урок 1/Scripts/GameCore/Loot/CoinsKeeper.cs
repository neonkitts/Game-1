using System;

namespace GameCore.Loot
{
    public class CoinsKeeper
    {
        public int Coins { get; private set; }

        public void AddCoin() => Coins++;

        public void AddCoins(int value)
        {
            if (value > 0)
                Coins += value;
            else
                throw new ArgumentOutOfRangeException(nameof(value));
        }
    }
}
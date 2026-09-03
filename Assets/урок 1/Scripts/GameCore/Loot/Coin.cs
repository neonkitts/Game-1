using GameCore.UI;
using Zenject;

namespace GameCore.Loot
{
    public class Coin : Loot
    {
        private CoinsUIUpdater _coinsUIUpdater;
        private CoinsKeeper _coinsKeeper;

        protected override void Pickup()
        {
            base.Pickup();
            _coinsKeeper.AddCoin();
            _coinsUIUpdater.OnCountChanged?.Invoke();
        }

        [Inject]
        private void Construct(CoinsUIUpdater coinsUIUpdater, CoinsKeeper coinsKeeper)
        {
            _coinsKeeper = coinsKeeper;
            _coinsUIUpdater = coinsUIUpdater;
        }
    }
}
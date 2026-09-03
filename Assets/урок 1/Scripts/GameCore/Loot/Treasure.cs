using GameCore.UI;
using Zenject;

namespace GameCore.Loot
{
    public class Treasure : Loot
    {
        private TreasureWindow _treasureWindow;
        protected override void Pickup()
        {
            base.Pickup();
            _treasureWindow.Activate();
        }

        [Inject] private void Construct(TreasureWindow treasureWindow) => 
            _treasureWindow = treasureWindow;
    }
    
   
}
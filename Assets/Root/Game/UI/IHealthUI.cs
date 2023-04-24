using Root.PixelGame.Game.Core.Health;

namespace Root.Game.UI
{
    internal interface IHealthUI
    {
        void InitUI(IHealth healthModel);

        void DeinitUI();
    }
}

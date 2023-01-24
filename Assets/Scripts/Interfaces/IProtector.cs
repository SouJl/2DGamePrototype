using PixelGame.View;

namespace PixelGame.Interfaces
{
    public interface IProtector
    {
        void StartProtection(LevelObjectView invader);
        void FinishProtection(LevelObjectView invader);
    }
}

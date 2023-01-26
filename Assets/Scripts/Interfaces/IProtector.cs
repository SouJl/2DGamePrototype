using PixelGame.View;
using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IProtector
    {
        Transform CurrentTarget { get; }

        void OnTargetReached();

        void StartProtection(LevelObjectView invader);
        void FinishProtection(LevelObjectView invader);
    }
}

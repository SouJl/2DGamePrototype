using Root.PixelGame.Game.Enemy;
using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal class StubEnemyCore : IEnemyCore
    {
        public StubEnemyCore()
            => Debug.Log($"Warning: {nameof(StubEnemyCore)} was created. Check EnemyCoreFactory logic implementation");

        public void Move(float time) { }

        public void Rotate(float time) { }

        public void UpdateCoreData(float time) { }
    }
}

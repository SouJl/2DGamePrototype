using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal class StubEnemyCore : IEnemyCore
    {
        public StubEnemyCore()
            => Debug.Log($"Warning: {nameof(StubEnemyCore)} was created");

        public StubEnemyCore(string coreOwnerName)
           => Debug.Log($"Warning: {nameof(StubEnemyCore)} was created by {coreOwnerName}");

        public void Move(float time) { }

        public void Rotate(float time) { }

        public void UpdateCoreData(float time) { }
    }
}

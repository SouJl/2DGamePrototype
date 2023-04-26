using Root.PixelGame.Tool;
using UnityEngine;

namespace Root.PixelGame.Game.Core
{
    internal class StubEnemyCore : IEnemyCore
    {
        public StubEnemyCore()
            => Debug.Log($"Warning: {nameof(StubEnemyCore)} was created");

        public StubEnemyCore(string coreOwnerName)
           => Debug.Log($"Warning: {nameof(StubEnemyCore)} was created by {coreOwnerName}");

        public IPhysicModel Physic { get; }

        public IGroundCheck GroundCheck { get; }

        public IWallCheck WallCheck { get; }

        public ISlopeAnaliser SlopeAnaliser { get; }
        public int FacingDirection { get; }

        public bool FlipAfterIdle { get; }

        public Transform Transform => throw new System.NotImplementedException();

        public bool CheckPlayerInRange() { return false; }

        public void Flip() { }

        public void Move(float time) { }

        public void Rotate(float time) { }

        public void SetFlipAfterIdle(bool isFlip)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCoreData(float time) { }
    }
}

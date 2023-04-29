using PixelGame.Tool;
using PixelGame.Tool.PlayerSearch;
using UnityEngine;

namespace PixelGame.Game.Core
{
    internal class StubEnemyCore : IEnemyCore
    {
        public StubEnemyCore()
            => Debug.Log($"Warning: {nameof(StubEnemyCore)} was created");

        public StubEnemyCore(string coreOwnerName)
           => Debug.Log($"Warning: {nameof(StubEnemyCore)} was created by {coreOwnerName}");

        public IPhysicModel Physic { get; }

        public IPlayerDetection PlayerDetection { get; }

        public IGroundCheck GroundCheck { get; }

        public IWallCheck WallCheck { get; }

        public ISlopeAnaliser SlopeAnaliser { get; }

        public int FacingDirection { get; }

        public bool FlipAfterIdle { get; }

        public Transform Transform { get; }


        public void Flip() { }

        public void Move(float time) { }

        public void Rotate(float time) { }

        public void SetFlipAfterIdle(bool isFlip) { }

        public void UpdateCoreData(float time) { }
    }
}

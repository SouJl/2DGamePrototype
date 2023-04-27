using UnityEngine;

namespace Root.PixelGame.Tool
{
    internal interface ITargetSelector
    {
        Transform CurrentTarget { get; }
        void ChangeTarget(Transform target);
    }

    internal abstract class AbstractTargetSelector : ITargetSelector
    {
        public abstract Transform CurrentTarget { get; }

        public virtual void ChangeTarget(Transform target) { }
    }
}

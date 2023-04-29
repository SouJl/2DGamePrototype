using UnityEngine;

namespace PixelGame.Tool
{
    internal class DynamicTargetSelector : AbstractTargetSelector
    {
        private Transform _target;

        public override Transform CurrentTarget => _target;

        public DynamicTargetSelector() { }

        public override void ChangeTarget(Transform target)
        {
            _target = target;
        }
    }
}

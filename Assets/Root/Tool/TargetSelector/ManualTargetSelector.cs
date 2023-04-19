using UnityEngine;

namespace Root.PixelGame.Tool
{
    internal class ManualTargetSelector : AbstractTargetSelector
    {
        private Transform _currentTarget;

        public ManualTargetSelector(Transform initTarget)
        {
            _currentTarget = initTarget;
        }

        public override Transform CurrentTarget => _currentTarget;
    }
}

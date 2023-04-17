﻿using Root.PixelGame.Components.AI;
using UnityEngine;

namespace Root.PixelGame.Components.Core
{
    [RequireComponent(typeof(SeekerAIViewComponent))]
    internal class StalkerCoreComponent : EnemyCoreComponent
    {
        [SerializeField] private SeekerAIViewComponent _aIViewComponent;
        public override IAIViewComponent AIViewComponent => _aIViewComponent;

        private void OnValidate()
        {
            _aIViewComponent ??= gameObject.GetComponent<SeekerAIViewComponent>();
        }
    }
}

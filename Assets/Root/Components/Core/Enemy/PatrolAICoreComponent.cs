﻿using Root.PixelGame.Components.AI;
using UnityEngine;

namespace Root.PixelGame.Components.Core
{
    [RequireComponent(typeof(PatrolAIComponent))]
    internal class PatrolAICoreComponent : EnemyCoreComponent
    {
        [SerializeField] private PatrolAIComponent _aIViewComponent;

        public override IAIViewComponent AIViewComponent => _aIViewComponent;

        private void OnValidate()
        {
            _aIViewComponent ??= gameObject.GetComponent<PatrolAIComponent>();
        }
    }
}

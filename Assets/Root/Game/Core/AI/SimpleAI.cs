using Root.PixelGame.Components.AI;
using Root.PixelGame.Game.AI.Model;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.AI
{
    internal class SimpleAI : BaseAI
    {
        private readonly IAIModel _model;
     
        public SimpleAI(
            IAIData data,
            IAIModel model) : base(data)
        {
            _model
                = model ?? throw new ArgumentNullException(nameof(model));

            Init();
        }

        public override void Init()
        {
            _model.InitModel();
        }

        public override void Deinit()
        {
            _model.DeinitModel();
        }

        public override Vector2 GetNewVelocity(Vector2 fromPosition) 
            => _model.CalculateVelocity(fromPosition);

    }
}

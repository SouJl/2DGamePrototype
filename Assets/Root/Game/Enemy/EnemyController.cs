using Root.PixelGame.Game.Core;
using System;
using UnityEngine;

namespace Root.PixelGame.Game.Enemy
{
    internal interface IEnemyController : IExecute
    {
        void OnCollisionContact(Collider2D collision);
    }

    internal class EnemyController : BaseController, IEnemyController
    {
        private readonly IEnemyView _view;
        private readonly IEnemyModel _model;
        private readonly IEnemyCore _core;

        public EnemyController(
            IEnemyView view, 
            IEnemyModel model,
            IEnemyCore core)
        {
            _view 
                = view ?? throw new ArgumentNullException(nameof(view));
            _model
              = model ?? throw new ArgumentNullException(nameof(model));
            _core 
                = core ?? throw new ArgumentNullException(nameof(core));

            _view.Init(this);
        }

        public override void Execute()
        {
            
        }

        public override void FixedExecute()
        {
            _core.UpdateCoreData(Time.fixedDeltaTime);
            _core.Move(fixedTime);
            _core.Rotate(fixedTime);
        }

        public void OnCollisionContact(Collider2D collision)
        {
            Debug.Log($"On Contact {collision.gameObject.name}");
        }

    }
}

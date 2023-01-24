using Pathfinding;
using PixelGame.Interfaces;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public class StalkerEnemyModel : AbstractAIEnemyModel<ILogicAI<Path>>
    {
        private Seeker _seeker;

        public Seeker Seeker { get => _seeker; }
        
        private float _speed;

        public float Speed { get => _speed;  }

        public StalkerEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, ILogicAI<Path> logicAI, Seeker seeker, float speed) : base(components, spriteRenderer, logicAI)
        {
            _seeker = seeker;
            _speed = speed;
        }

        public override void Rotate(Vector3 target)
        {
            if (UnitComponents.RgdBody.velocity.x > 0)
            {
                UnitComponents.Transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else 
            {
                UnitComponents.Transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }


        public override void RecalculatePath(Vector3 target)
        {
            if (Seeker.IsDone())
            {
                Seeker.StartPath(UnitComponents.RgdBody.position, target, LogicAI.OnPathComplete);
            }
        }
    }
}

using Pathfinding;
using PixelGame.Interfaces;
using PixelGame.Model.AIModels;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public class StandartAIEnemyModel : AbstractAIEnemyModel
    {
        
        private float _speed;

        public float Speed { get => _speed;  }

        public StandartAIEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, AbstractAIModel logicAI, float speed) : base(components, spriteRenderer, logicAI)
        {
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


        public override void RecalculatePath()
        {
            LogicAI.RecalculatePath();
        }

        public override void Move()
        {
            UnitComponents.RgdBody.velocity = LogicAI.CalculateVelocity(UnitComponents.RgdBody.position) * Speed * Time.fixedDeltaTime;
        }
    }
}

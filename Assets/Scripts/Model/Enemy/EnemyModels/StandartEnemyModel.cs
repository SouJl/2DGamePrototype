using PixelGame.Model.AIModels;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public class StandartEnemyModel : AbstractAIEnemyModel
    {
        private AbstractAI _aImodel;
        private float _speed;
        private float _moveThresh;

        public float Speed { get => _speed;  }
        public float MoveThresh { get => _moveThresh;}

        private int FacingDirection;

        public StandartEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, AbstractAI aImodel, float speed, float moveThresh) : base(components, spriteRenderer)
        {
            _aImodel = aImodel;
            _speed = speed;
            _moveThresh = moveThresh;
            FacingDirection = 1;
        }

        public override void Rotate(Vector3 target)
        {
            float xInpunt = UnitComponents.RgdBody.velocity.x;

            if (xInpunt != 0 && (xInpunt * FacingDirection) < 0)
            {
                FacingDirection *= -1;
                UnitComponents.Transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }

        public override void Update(float time)
        {
            _aImodel.Update(time);
        }

        public override void Move()
        {
            var newVel = _aImodel.CalculateVelocity(UnitComponents.Transform.position) * Speed * Time.fixedDeltaTime;

            if (Mathf.Abs(newVel.x) > _moveThresh)
                UnitComponents.RgdBody.velocity = newVel;
        }
    }
}

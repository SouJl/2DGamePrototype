using PixelGame.Configs;
using PixelGame.Model.AIModels;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public class StandartEnemyModel : AbstractEnemyModel
    {
        private AbstractAI _aImodel;

        private int FacingDirection;

        public StandartEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, EnemyData data, AbstractAI aImodel) : base(components, spriteRenderer, data)
        {
            _aImodel = aImodel;
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
            var newVel = _aImodel.CalculateVelocity(UnitComponents.Transform.position) * Data.speed * Time.fixedDeltaTime;

            if (Mathf.Abs(newVel.x) > Data.moveThresh)
                UnitComponents.RgdBody.velocity = newVel;
        }

        public override void Dispose()
        {
            
        }
    }
}

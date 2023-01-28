using Pathfinding;
using PixelGame.Configs;
using PixelGame.Model.AIModels;
using PixelGame.Model.Utils;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model
{
    public class ProtectorEnemyModel : AbstractEnemyModel
    {
        private AbstractAI _patrolModelAI;

        private AbstractAI _stalkerModelAI;

        private Transform _target;
        private LevelObjectTrigger _trigger;

        private AbstractAI _currentModelAI;

        private int FacingDirection;

        private float _currentSpeed;
        private float _speedMultiplier;

        public ProtectorEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, EnemyData data, AIConfig aIConfig, Seeker seeker, LevelObjectTrigger trigger, Transform target, float speedMuliplier) : base(components, spriteRenderer, data)
        {
            _trigger = trigger;
            _speedMultiplier = speedMuliplier;
            _target = target;

            _patrolModelAI = new PatrolAI(aIConfig, UnitComponents, seeker);
            _stalkerModelAI = new StalkerAI(aIConfig, UnitComponents, seeker, _target);

            _trigger.TriggerEnter += StartProtection;
            _trigger.TriggerExit += FinishProtection;

            FacingDirection = 1;
            _currentSpeed = Data.speed;
            
            ChangeAI(_patrolModelAI);
        }

        public override void Update(float time)
        {
            _currentModelAI.Update(time);
        }

        public override void Move()
        {
            var newVel = _currentModelAI.CalculateVelocity(UnitComponents.Transform.position) * _currentSpeed * Time.fixedDeltaTime;

            if (Mathf.Abs(newVel.x) > 0.01)
                UnitComponents.RgdBody.velocity = newVel;
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

        private void StartProtection(LevelObjectView invader)
        {
            if (invader.gameObject.tag != _target.gameObject.tag) return;

            _currentSpeed *= _speedMultiplier;

            ChangeAI(_stalkerModelAI);
        }

        private void FinishProtection(LevelObjectView invader)
        {
            if (invader.gameObject.tag != _target.gameObject.tag) return;

            _currentSpeed = Data.speed;

            ChangeAI(_patrolModelAI);
        }


        private void ChangeAI(AbstractAI newAI)
        {
            if (_currentModelAI == null)
            {
                _currentModelAI = newAI;
                _currentModelAI.Init();
                return;
            }

            _currentModelAI.Deint();
            _currentModelAI = newAI;
            _currentModelAI.Init();
        }

        public override void Dispose()
        {
            _trigger.TriggerEnter -= StartProtection;
            _trigger.TriggerExit -= FinishProtection;
        }
    }
}

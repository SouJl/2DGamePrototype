using Pathfinding;
using PixelGame.Configs;
using PixelGame.Model.AIModels;
using PixelGame.Model.Utils;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model
{
    public class ChaserEnemyModel : AbstractEnemyModel
    {
        private AbstractAI _patrolModelAI;
        private AbstractAI _stalkerModelAI;
        private Transform _target;
        private LevelObjectTrigger _trigger;

        private AbstractAI _currentModelAI;

        private int FacingDirection;

        private float _chaseDistanceBreak;

        private bool _isChaseTarget;

        public ChaserEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, EnemyData data, AIConfig aIConfig, Seeker seeker, LevelObjectTrigger trigger, Transform target, float chaseBreak) : base(components, spriteRenderer, data)
        {
            _target = target;
            _trigger = trigger;
            _chaseDistanceBreak = chaseBreak;

            _patrolModelAI = new PatrolAI(aIConfig, UnitComponents, seeker);
            _stalkerModelAI = new StalkerAI(aIConfig, UnitComponents, seeker, _target);

            _trigger.TriggerEnter += OnTargetTriggered;

            FacingDirection = 1;
            _isChaseTarget = false;

            ChangeAI(_patrolModelAI);
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
            _currentModelAI.Update(time);

            if (_isChaseTarget)
            {
                var distance = Vector2.Distance(UnitComponents.Transform.position, _target.position);

                if (distance > _chaseDistanceBreak)
                {
                    _isChaseTarget = false;
                    ChangeAI(_patrolModelAI);
                }
            }
        }

        public override void Move()
        {
            var newVel = _currentModelAI.CalculateVelocity(UnitComponents.Transform.position) * Data.speed * Time.fixedDeltaTime;

            if (Mathf.Abs(newVel.x) > 0.01)
                UnitComponents.RgdBody.velocity = newVel;
        }


        private void OnTargetTriggered(LevelObjectView levelObject)
        {
            if (levelObject.gameObject.tag != _target.gameObject.tag) return;

            ChangeAI(_stalkerModelAI);
            _isChaseTarget = true;
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
            _trigger.TriggerEnter -= OnTargetTriggered;
        }
    }
}

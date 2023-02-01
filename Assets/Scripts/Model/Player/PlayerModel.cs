using PixelGame.Configs;
using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public class PlayerModel : AbstractUnitModel
    {
        #region States Variables

        public State RunState { get; set; }
        public State InAirState { get; set; }
        public State LandState { get; set; }
        public State JumpState { get; set; }
        public State FallState { get; set; }
        public State WallSlideState { get; set; }
        public State WallClimbState { get; set; }
        public State WallGrabState { get; set; }
        public State WallJumpState { get; set; }
        public State LedgeState { get; set; }
        public State ClimbState { get; set; }


        #endregion

        #region Private Variables

        private float _maxHealth;
        private SlopeAnaliser _slope;
        private PhysicsMaterial2D _mainMaterial;

        private IMove _moveModel;

        private Vector2 _workVelocity;

        #endregion

        #region Public Variables

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public SlopeAnaliser Slope { get => _slope; set => _slope = value; }
        public PhysicsMaterial2D MainMaterial { get => _mainMaterial; private set => _mainMaterial = value; }

        public IMove MoveModel { get => _moveModel; }
       
        public bool CanSetVelocity { get; set; }
        public int WallJumpDirection { get; set; }
        public Vector2 LedgeDetectPos { get; private set; }

        #endregion

        public PlayerModel(ComponentsModel components, SpriteRenderer spriteRenderer, ContactsPollerModel contactsPoller, float maxHealth, PlayerData playerData, SlopeAnaliser slope) : base(components, spriteRenderer, contactsPoller)
        {
            _maxHealth = maxHealth;
            _moveModel = new SimplePhysicsMove(this);
            _slope = slope;

            MainMaterial = Resources.Load<PhysicsMaterial2D>("PlayerPhysicsMaterial");
            FacingDirection = 1;

            CanSetVelocity = true;
        }

        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {
            angle.Normalize();
            _workVelocity.Set(angle.x * velocity * direction, angle.y * velocity);
            SetFinalVelocity();
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            _workVelocity = direction * velocity;
            SetFinalVelocity();
        }

        public override void SetVelocityX(float velocity)
        {
            _workVelocity.Set(velocity, CurrentVelocity.y);
            SetFinalVelocity();
        }

        public override void SetVelocityY(float velocity)
        {
            _workVelocity.Set(CurrentVelocity.x, velocity);
            SetFinalVelocity();
        }

        public override void CheckFlip(float xInpunt)
        {
            if (xInpunt != 0 && (xInpunt * FacingDirection) < 0)
            {
                FacingDirection *= -1;
                UnitComponents.Transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }

        public void DetermineWallJumpDirection(bool isTouchingWall)
        {
            WallJumpDirection = (isTouchingWall ? -1 : 1) * FacingDirection;
        }

        private void SetFinalVelocity() 
        {
            if (CanSetVelocity) MoveModel.Move(_workVelocity);
        }

        public void SetDetectedPos(Vector2 pos) => LedgeDetectPos = pos;

        public void SetVelocityZero()
        {
            UnitComponents.RgdBody.velocity = Vector2.zero;
            CurrentVelocity = Vector2.zero;
        }  
    }
}


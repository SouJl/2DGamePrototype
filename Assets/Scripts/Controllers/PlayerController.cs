using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.Model.StateMachines;
using PixelGame.Model.Utils;
using PixelGame.View;

namespace PixelGame.Controllers
{
    public class PlayerController: IExecute
    {
        private PlayerModel _playerModel;
        private PlayerView _view;
        private SpriteAnimatorController _animatorController;

        private HealthController _healthController;

        public PlayerController(PlayerView view, HealhBarView healhBar) 
        {
            _view = view;
            var componentsModel = new ComponentsModel(_view.Transform, _view.Rigidbody, _view.Collider);

            var contactsPoller = new ContactsPollerModel(_view.Collider, _view.GroundCheck);
            var slope = new SlopeAnaliser(_view.Rigidbody, _view.Collider, _view.SlopeData.slopeCheckDistance, _view.SlopeData.maxSlopeAngle, _view.SlopeData.layerMask);
            _playerModel = new PlayerModel(componentsModel, _view.SpriteRenderer, contactsPoller, _view.MaxHealth, _view.PlayerData, slope);

            _animatorController = new SpriteAnimatorController(_view.AnimationConfig, _view.AnimationSpeed);
            _healthController = new HealthController(_playerModel.MaxHealth, healhBar);

            InitStateMachine();
        }

        private void InitStateMachine() 
        {
            _playerModel.UnitMovementSM = new StateMachine();
            _playerModel.IdleState = new PlayerIdleState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.PlayerData, AnimaState.Idle);
            _playerModel.RunState = new PlayerMoveState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.PlayerData, AnimaState.Run);
            _playerModel.JumpState = new PlayerJumpState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.PlayerData, AnimaState.InAir);
            _playerModel.InAirState = new PlayerInAirState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.PlayerData, AnimaState.InAir);
            _playerModel.LandState = new PlayerLandState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.PlayerData, AnimaState.Idle);
            _playerModel.FallState = new PlayerFallState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.PlayerData, AnimaState.Fall);
            _playerModel.RollState = new PlayerRollState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.PlayerData, AnimaState.Roll, _view.AnimationSpeed);
            _playerModel.WallGrabState = new PlayerWallGrabState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.PlayerData, AnimaState.WallGrab);
            _playerModel.WallSlideState = new PlayerWallSlideState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.PlayerData, AnimaState.WallSlide);

            _playerModel.UnitMovementSM.Initialize(_playerModel.IdleState);
        }

        public void Execute()
        {
            _playerModel.UnitMovementSM.CurrentState.InputData();
            _playerModel.UnitMovementSM.CurrentState.LogicUpdate();
            _healthController.Execute();
        }

        public void FixedExecute()
        {
            _playerModel.CurrentVelocity = _playerModel.UnitComponents.RgdBody.velocity;

            _playerModel.UnitMovementSM.CurrentState.PhysicsUpdate();
        }
    }
}

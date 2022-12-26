using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.Model.StateMachines;
using PixelGame.View;

namespace PixelGame.Controllers
{
    public class PlayerController: IExecute
    {
        private PlayerModel _playerModel;
        private PlayerView _view;
        private SpriteAnimatorController _animatorController;

        public PlayerController(PlayerView view) 
        {
            _view = view;
            var moveModel = new PlayerMovementModel(_view.Rigidbody, _view.Speed, _view.MoveThresh);
            var jumpModel = new PlayerJumpModel(_view.Rigidbody, _view.JumpForce, _view.JumpThreshold, _view.FlyThreshold);
            _playerModel = new PlayerModel(_view.SpriteRenderer, _view.Collider , moveModel, jumpModel, _view.MaxHealth);

            _animatorController = new SpriteAnimatorController(_view.AnimationConfig, _view.AnimationSpeed);

            InitStateMachine();
        }

        private void InitStateMachine() 
        {
            _playerModel.UnitMovementSM = new StateMachine();
            _playerModel.IdleState = new PlayerIdleState(_playerModel.UnitMovementSM, _animatorController, _playerModel);
            _playerModel.RunState = new PlayerRunState(_playerModel.UnitMovementSM, _animatorController, _playerModel);
            _playerModel.JumpState = new PlayerJumpState(_playerModel.UnitMovementSM, _animatorController, _playerModel);
            _playerModel.RollState = new PlayerRollState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.RollFrames, _view.AnimationSpeed);

            _playerModel.UnitMovementSM.Initialize(_playerModel.IdleState);
        }

        public void Execute()
        {
            _playerModel.UnitMovementSM.CurrentState.InputData();
            _playerModel.UnitMovementSM.CurrentState.LogicUpdate();
        }

        public void FixedExecute()
        {
            _playerModel.ContactsPoller.Update();
            _playerModel.UnitMovementSM.CurrentState.PhysicsUpdate();
        }
    }
}

using PixelGame.Enumerators;
using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.Model.StateMachines;
using PixelGame.View;

namespace PixelGame.Controllers
{
    public class PlayerController: IExecute
    {
        private PlayerModel _playerModel;
        private SpriteAnimatorController _animatorController;

        public PlayerController(PlayerView view) 
        {
            var moveModel = new PlayerMovementModel(view.Rigidbody, view.Speed, view.MoveThresh);
            var jumpModel = new PlayerJumpModel(view.Rigidbody, view.JumpForce, view.JumpThreshold);
            _playerModel = new PlayerModel(view.SpriteRenderer, view.Collider , moveModel, jumpModel, view.MaxHealth);

            _animatorController = new SpriteAnimatorController(view.AnimationConfig, view.AnimationSpeed);

            InitStateMachine();
        }

        private void InitStateMachine() 
        {
            _playerModel.UnitMovementSM = new StateMachine();
            _playerModel.IdleState = new PlayerIdleState(_playerModel, _playerModel.UnitMovementSM, _animatorController);
            _playerModel.RunState = new PlayerRunState(_playerModel, _playerModel.UnitMovementSM, _animatorController);
            _playerModel.JumpState = new PlayerJumpState(_playerModel, _playerModel.UnitMovementSM, _animatorController);

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

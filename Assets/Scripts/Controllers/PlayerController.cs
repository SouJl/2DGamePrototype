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
            _playerModel = new PlayerModel(view.SpriteRenderer, view.Speed, view.Rigidbody, view.MaxHealth);

            _animatorController = new SpriteAnimatorController(view.AnimationConfig);

            InitStateMachine();
        }

        private void InitStateMachine() 
        {
            _playerModel.UnitMovementSM = new StateMachine();
            _playerModel.Idle = new PlayerIdleState(_playerModel, _playerModel.UnitMovementSM, _animatorController, 0.01f);
            _playerModel.Run = new PlayerRunState(_playerModel, _playerModel.UnitMovementSM, _animatorController);
            _playerModel.UnitMovementSM.Initialize(_playerModel.Idle);
        }

        public void Execute()
        {
            _playerModel.UnitMovementSM.CurrentState.InputData();
            _playerModel.UnitMovementSM.CurrentState.LogicUpdate();
        }

        public void FixedExecute()
        {
            _playerModel.UnitMovementSM.CurrentState.PhysicsUpdate();
        }
    }
}

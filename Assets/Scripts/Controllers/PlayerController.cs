﻿using PixelGame.Interfaces;
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
            var moveModel = new SimplePhysicsMove(_view.Rigidbody, _view.Speed, _view.MoveThresh);
            var jumpModel = new PlayerJumpModel(_view.Rigidbody, _view.JumpForce, _view.JumpThreshold, _view.FlyThreshold, _view.FallThreshold);
            var contactsPoller = new ContactsPollerModel(_view.Collider, _view.GroundCheck);
            var slope = new SlopeAnaliser(_view.Rigidbody, _view.Collider, _view.SlopeData.slopeCheckDistance, _view.SlopeData.maxSlopeAngle, _view.SlopeData.layerMask);
            _playerModel = new PlayerModel(componentsModel, _view.SpriteRenderer, moveModel, jumpModel, contactsPoller, _view.MaxHealth, slope);

            _animatorController = new SpriteAnimatorController(_view.AnimationConfig, _view.AnimationSpeed);
            _healthController = new HealthController(_playerModel.MaxHealth, healhBar);

            InitStateMachine();
        }

        private void InitStateMachine() 
        {
            _playerModel.UnitMovementSM = new StateMachine();
            _playerModel.IdleState = new PlayerIdleState(_playerModel.UnitMovementSM, _animatorController, _playerModel);
            _playerModel.RunState = new PlayerRunState(_playerModel.UnitMovementSM, _animatorController, _playerModel);
            _playerModel.JumpState = new PlayerJumpState(_playerModel.UnitMovementSM, _animatorController, _playerModel);
            _playerModel.FallState = new PlayerFallState(_playerModel.UnitMovementSM, _animatorController, _playerModel);
            _playerModel.RollState = new PlayerRollState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.RollFrames, _view.AnimationSpeed);
            _playerModel.WallSlideState = new PlayerWallSlideState(_playerModel.UnitMovementSM, _animatorController, _playerModel, _view.WallSlideSpeed);

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
            _playerModel.UnitMovementSM.CurrentState.PhysicsUpdate();
            _playerModel.ContactsPoller.Update();
        }
    }
}

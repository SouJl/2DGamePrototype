using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using System;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractUnitModel
    {
        public StateMachine UnitMovementSM { get; set; }
        public State IdleState { get; set; }
        public State RunState { get; set; }
        public State JumpState { get; set; }

        private SpriteRenderer _spriteRenderer;
        private ContactsPollerModel _contactsPoller;
        private IMove _moveModel;
        private IJump _jumpModel;

        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
        public ContactsPollerModel ContactsPoller { get => _contactsPoller; set => _contactsPoller = value; }
        public IMove MoveModel { get => _moveModel; }
        public IJump JumpModel { get => _jumpModel; }

        public AbstractUnitModel(SpriteRenderer spriteRenderer, Collider2D collider2D, IMove movementModel, IJump jumpModel)
        {
            _spriteRenderer = spriteRenderer;
            _contactsPoller = new ContactsPollerModel(collider2D);
            _moveModel = movementModel;
            _jumpModel = jumpModel;
        }
    }
}

using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using System;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractUnitModel
    {
        public StateMachine UnitMovementSM { get; set; }
        public State Idle { get; set; }
        public State Run { get; set; }
        public State Jump { get; set; }

        private SpriteRenderer _spriteRenderer;
        private ContactsPollerModel _contactsPoller;
        private IMove _moveModel;

        public SpriteRenderer SpriteRenderer 
        { 
            get => _spriteRenderer; 
            set => _spriteRenderer = value; 
        }
        
        public ContactsPollerModel ContactsPoller
        {
            get => _contactsPoller;
            set => _contactsPoller = value;
        }

        public IMove MoveModel 
        { 
            get => _moveModel; 
            set => _moveModel = value; 
        }
       

        public AbstractUnitModel(SpriteRenderer spriteRenderer, Collider2D collider2D,  IMove movementModel) 
        {
            _spriteRenderer = spriteRenderer;
            _contactsPoller = new ContactsPollerModel(collider2D);
            _moveModel = movementModel;
        }
    }
}

using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractEnemyModel
    {
        public StateMachine UnitMovementSM { get; set; }
        public State IdleState { get; set; }
        
        private SpriteRenderer _spriteRenderer;
        private ContactsPollerModel _contactsPoller;

        private IMove _moveModel;

        private ILogicAI _logicAI;
       
       
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
        public ContactsPollerModel ContactsPoller { get => _contactsPoller; set => _contactsPoller = value; }
        
        public IMove MoveModel { get => _moveModel; }
        public ILogicAI LogicAI { get => _logicAI; }

        public AbstractEnemyModel(SpriteRenderer spriteRenderer, Collider2D collider2D, IMove movementModel, ILogicAI logicAI) 
        {
            _spriteRenderer = spriteRenderer;
            _contactsPoller = new ContactsPollerModel(collider2D);
            _moveModel = movementModel;
            _logicAI = logicAI;
        }

        public abstract void Rotate(Vector3 target);
    }
}

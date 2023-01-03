using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractUnitModel
    {
        public StateMachine UnitMovementSM { get; set; }
        public State IdleState { get; set; }

        private Rigidbody2D _rgBody;
        private SpriteRenderer _spriteRenderer;
        private ContactsPollerModel _contactsPoller;
        private IMove _moveModel;
        private IJump _jumpModel;

        public Rigidbody2D RgBody { get => _rgBody; set => _rgBody = value; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
        public ContactsPollerModel ContactsPoller { get => _contactsPoller; set => _contactsPoller = value; }
        public IMove MoveModel { get => _moveModel; }
        public IJump JumpModel { get => _jumpModel; }

        public AbstractUnitModel(Rigidbody2D rigidbody, SpriteRenderer spriteRenderer, Collider2D collider2D, IMove movementModel, IJump jumpModel)
        {
            _rgBody = rigidbody;
            _spriteRenderer = spriteRenderer;
            _contactsPoller = new ContactsPollerModel(collider2D);
            _moveModel = movementModel;
            _jumpModel = jumpModel;
        }
    }
}

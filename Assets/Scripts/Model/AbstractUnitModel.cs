using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractUnitModel :IUnit
    {
        public StateMachine UnitMovementSM { get; set; }
        public State IdleState { get; set; }

        private ComponentsModel _unitComponents;
        private SpriteRenderer _spriteRenderer;
        private ContactsPollerModel _contactsPoller;
        private IMove _moveModel;
        private IJump _jumpModel;

        public ComponentsModel UnitComponents { get => _unitComponents; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer;}
        public ContactsPollerModel ContactsPoller { get => _contactsPoller; set => _contactsPoller = value; }
        public IMove MoveModel { get => _moveModel; }
        public IJump JumpModel { get => _jumpModel; }

        public AbstractUnitModel(ComponentsModel components, SpriteRenderer spriteRenderer, IMove movementModel, IJump jumpModel)
        {
            _unitComponents = components;
            _spriteRenderer = spriteRenderer;
            _contactsPoller = new ContactsPollerModel(UnitComponents.Collider);
            _moveModel = movementModel;
            _jumpModel = jumpModel;
        }
    }
}

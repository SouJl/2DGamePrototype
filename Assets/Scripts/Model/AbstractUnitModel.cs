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

        public ComponentsModel UnitComponents { get => _unitComponents; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer;}
        public ContactsPollerModel ContactsPoller { get => _contactsPoller; set => _contactsPoller = value; }
        
        public Vector2 CurrentVelocity { get; set; }

        public int FacingDirection { get; set; }

        public AbstractUnitModel(ComponentsModel components, SpriteRenderer spriteRenderer, ContactsPollerModel contactsPoller)
        {
            _unitComponents = components;
            _spriteRenderer = spriteRenderer;
            _contactsPoller = contactsPoller;
        }

        public abstract void SetVelocityX(float velocity);

        public abstract void SetVelocityY(float velocity);

        public abstract void CheckFlip(float xInpunt);
    }
}

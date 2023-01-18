using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model 
{
    public class PlayerModel: AbstractUnitModel
    {
        public State RunState { get; set; }
        public State JumpState { get; set; }
        public State FallState { get; set; }
        public State RollState { get; set; }
        public State WallSlideState { get; set; }

        private float _maxHealth;
        private SlopeAnaliser _slope;
        private PhysicsMaterial2D _fullFriction;
        private PhysicsMaterial2D _noneFriction;

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public SlopeAnaliser Slope { get => _slope; set => _slope = value; }
        
        public PhysicsMaterial2D FullFriction { get => _fullFriction; private set => _fullFriction = value; }
        public PhysicsMaterial2D NoneFriction { get => _noneFriction; private set => _noneFriction = value; }

        public PlayerModel(ComponentsModel components, SpriteRenderer spriteRenderer, IMove movementModel, IJump jumpModel, float maxHealth, SlopeAnaliser slope) : base(components, spriteRenderer, movementModel, jumpModel)
        {
            _maxHealth = maxHealth;
            _slope = slope;

            FullFriction = Resources.Load<PhysicsMaterial2D>("FullFrictionMaterial");
            NoneFriction = Resources.Load<PhysicsMaterial2D>("ZeroFrictionMaterial");
        }
    }
}


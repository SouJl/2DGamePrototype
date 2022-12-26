using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using UnityEngine;

namespace PixelGame.Model 
{
    public class PlayerModel: AbstractUnitModel
    {
        public State RunState { get; set; }
        public State JumpState { get; set; }
        public State FallState { get; set; }
        public State RollState { get; set; }

        private float _maxHealth;

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

        public PlayerModel(SpriteRenderer spriteRenderer, Collider2D collider2D, IMove movementModel, IJump jumpModel, float maxHealth) : base(spriteRenderer, collider2D, movementModel, jumpModel)
        {
            _maxHealth = maxHealth;
        }

    }
}


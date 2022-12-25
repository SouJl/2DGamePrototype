using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model 
{
    public class PlayerModel: AbstractUnitModel
    {
        private float _maxHealth;

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

        public PlayerModel(SpriteRenderer spriteRenderer, Collider2D collider2D, IMove movementModel, IJump jumpModel, float maxHealth) : base(spriteRenderer, collider2D, movementModel, jumpModel)
        {
            _maxHealth = maxHealth;
        }

    }
}

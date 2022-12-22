using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model 
{
    public class PlayerModel: AbstractUnitModel
    {
        private Rigidbody2D _rgdBody;
        private float _maxHealth;

  
        public Rigidbody2D RgdBody { get => _rgdBody; set => _rgdBody = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }

        public PlayerModel(SpriteRenderer spriteRenderer, float speed, Rigidbody2D rgdbody, float maxHealth) : base(spriteRenderer, speed)
        {
            _rgdBody = rgdbody;
            _maxHealth = maxHealth;
        }

        public override void Move(Vector2 input)
        {
            RgdBody.MovePosition(RgdBody.position + input * Speed * Time.fixedDeltaTime);
        }
    }
}


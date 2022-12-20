using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model 
{
    public class PlayerModel: IMove
    {
        private Rigidbody2D _rgdBody;
        private float _maxHealth;
        private float _speed;
       
        public Rigidbody2D RgdBody { get => _rgdBody; set => _rgdBody = value; }
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float Speed { get => _speed; set => _speed = value; }
        
        public PlayerModel(Rigidbody2D rgdbody, float maxHealth, float speed)
        {
            RgdBody = rgdbody;
            MaxHealth = maxHealth;
            Speed = speed;
        }

        public void Move(Vector2 input)
        {
            RgdBody.MovePosition(RgdBody.position + input * Speed * Time.fixedDeltaTime);
        }
    }
}


using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using System;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractUnitModel : IMove
    {
        public StateMachine UnitMovementSM { get; set; }
        public State Idle { get; set; }
        public State Run { get; set; }
        public State Jump { get; set; }

        private SpriteRenderer _spriteRenderer;
        private float _speed;

        public float Speed 
        { 
            get => _speed; 
            set => _speed = value; 
        }
        public SpriteRenderer SpriteRenderer 
        { 
            get => _spriteRenderer; 
            set => _spriteRenderer = value; 
        }

        public AbstractUnitModel(SpriteRenderer spriteRenderer, float speed) 
        {
            _spriteRenderer = spriteRenderer;
            _speed = speed;
        }

        public abstract void Move(Vector2 input);
    }
}

﻿using PixelGame.Interfaces;
using PixelGame.Model.AIModels;
using PixelGame.Model.StateMachines;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractAIEnemyModel: IUnit
    {
        public StateMachine UnitMovementSM { get; set; }
        public State IdleState { get; set; }

        private ComponentsModel _unitComponents;
        private SpriteRenderer _spriteRenderer;

        public ComponentsModel UnitComponents { get => _unitComponents; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; }
        

        public Vector2 CurrentVelocity { get; set; }

        public Vector2 WorkVelocity { get; set; }

        public AbstractAIEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer) 
        {
            _unitComponents = components;
            _spriteRenderer = spriteRenderer;
        }

        public abstract void Move();

        public abstract void Rotate(Vector3 target);

        public abstract void Update(float time);

    }
}

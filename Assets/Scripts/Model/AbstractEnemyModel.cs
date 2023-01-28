using PixelGame.Configs;
using PixelGame.Interfaces;
using PixelGame.Model.AIModels;
using PixelGame.Model.StateMachines;
using PixelGame.Model.Utils;
using System;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractEnemyModel: IUnit, IDisposable
    {
        public StateMachine UnitMovementSM { get; set; }
        public State IdleState { get; set; }

        private ComponentsModel _unitComponents;
        private SpriteRenderer _spriteRenderer;
        private EnemyData _data;


        public ComponentsModel UnitComponents { get => _unitComponents; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; }
        public EnemyData Data { get => _data;}

        public Vector2 CurrentVelocity { get; set; }

        public Vector2 WorkVelocity { get; set; }

        public AbstractEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, EnemyData data) 
        {
            _unitComponents = components;
            _spriteRenderer = spriteRenderer;
            _data = data;
        }

        public abstract void Move();

        public abstract void Rotate(Vector3 target);

        public abstract void Update(float time);

        public abstract void Dispose();
    }
}

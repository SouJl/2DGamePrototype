﻿using Assets.PixelGame.Components;
using PixelGame.Game.Core;
using System;
using UnityEngine;

namespace PixelGame.Game.Enemy
{
    internal interface IEnemyView
    {
        Transform EnemyTransform { get; }

        void SetActive(bool state);

        void Init(IEnemyController controller);
    }

    internal abstract class EnemyView : UnitView, IEnemyView
    {
        private IEnemyController _controller;

        [SerializeField] private AnimationViewComponent _animation; 

        public AnimationViewComponent Animation => _animation;

        public Transform EnemyTransform => gameObject.transform;

        public virtual void Init(IEnemyController controller)
        {
            _controller = controller;
        }

        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

        public override void Damage(float amount)
        {
            _controller.Damage(amount);
        }

        public override void Knockback(Vector2 angle, float strength, int direction)
        {
            _controller.Knockback(angle, strength, direction);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_controller == null) return;

            _controller.OnCollisionContact(collision);
        } 
    }
}

﻿using PixelGame.Components;
using UnityEngine;

namespace PixelGame.Model
{
    public class ContactsPollerModel
    {
        private const float _collisionThresh = 0.3f;
        private const int _minCollSideContatcs = 2;
        private ContactPoint2D[] _contacts = new ContactPoint2D[10];
        private int _contactsCount;
        private readonly Collider2D _collider2D;

        public bool IsGrounded { get; private set; }
        public Vector2 GroundVelocity { get; private set; }
        public bool HasLeftContacts { get; private set; }
        public bool HasRightContacts { get; private set; }

        public Vector2 GroundCheckSize { get => _groundCheckSize; }

        private Transform _groundCheckPos;
        private Vector2 _groundCheckSize;
        private LayerMask _groundLayerMask;

        public ContactsPollerModel(Collider2D collider2D, GroundCheckComponent groundCheck)
        {
            _collider2D = collider2D;
            _groundCheckPos = groundCheck.GroundCheck;
            _groundCheckSize = new Vector2(groundCheck.Width, groundCheck.Height);
            _groundLayerMask = groundCheck.LayerMask;
        }

        public void Update()
        {
            IsGrounded = false;
            HasLeftContacts = false;
            HasRightContacts = false;
            _contactsCount = _collider2D.GetContacts(_contacts);

            IsGrounded = CheckGround();

            for (int i = 0; i < _contactsCount; i++)
            {
                var normal = _contacts[i].normal;
                var rigidBody = _contacts[i].rigidbody;

                if (_contactsCount > _minCollSideContatcs)
                {
                    if (normal.x > _collisionThresh)
                        HasLeftContacts = true;

                    if (normal.x < -_collisionThresh)
                        HasRightContacts = true;
                }
            }

            
        }

        private bool CheckGround() 
        {
            var hit = Physics2D.OverlapBox(_groundCheckPos.position, _groundCheckSize, 0f, _groundLayerMask);
            
            Color rayColor;
            if (hit != null)
            {
                rayColor = Color.blue;
                GroundVelocity = hit.attachedRigidbody.velocity;
            }
            else 
            {
                rayColor = Color.red;
                GroundVelocity = Vector2.zero;
            }

            Debug.DrawRay(_groundCheckPos.position, Vector2.down * 0.5f, rayColor);

            return hit != null;
        }
    }
}

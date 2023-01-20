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

        private Transform _groundCheck;

        public ContactsPollerModel(Collider2D collider2D)
        {
            _collider2D = collider2D;
        }

        public void Update()
        {
            IsGrounded = false;
            HasLeftContacts = false;
            HasRightContacts = false;
            _contactsCount = _collider2D.GetContacts(_contacts);

            for (int i = 0; i < _contactsCount; i++)
            {
                var normal = _contacts[i].normal;
                var rigidBody = _contacts[i].rigidbody;
                
                if (normal.y > _collisionThresh)
                {
                    IsGrounded = true;
                    GroundVelocity = rigidBody == null ? Vector2.zero : rigidBody.velocity;
                }

                if (_contactsCount > _minCollSideContatcs)
                {
                    if (normal.x > _collisionThresh && rigidBody == null)
                        HasLeftContacts = true;

                    if (normal.x < -_collisionThresh && rigidBody == null)
                        HasRightContacts = true;
                }
            }
        }
    }
}

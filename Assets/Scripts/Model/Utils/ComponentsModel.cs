using UnityEngine;

namespace PixelGame.Model.Utils
{
    public class ComponentsModel
    {
        private Transform _transform;
        
        private Rigidbody2D _rgdBody;
        
        private Collider2D _collider;

        public Transform Transform { get => _transform; set => _transform = value; }
        public Rigidbody2D RgdBody { get => _rgdBody;  set => _rgdBody = value; }
        public Collider2D Collider { get => _collider;  set => _collider = value; }

        public ComponentsModel(Transform transform, Rigidbody2D rigidbody, Collider2D collider) 
        {
            Transform = transform;
            RgdBody = rigidbody;
            Collider = collider;
        }
    }
}

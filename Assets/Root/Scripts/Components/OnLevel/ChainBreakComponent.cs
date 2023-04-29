using UnityEngine;

namespace PixelGame.Components
{
    [RequireComponent(typeof(DistanceJoint2D))]
    internal class ChainBreakComponent : MonoBehaviour
    {
        [SerializeField] private DistanceJoint2D _joint;
        [SerializeField] private Collider2D _collider;

        private void Awake()
        {
            _collider.isTrigger = true;
        }

        private void OnValidate()
        {
            _joint = gameObject.GetComponent<DistanceJoint2D>();
            _collider = gameObject.GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                _joint.breakForce = 0;
            }
        }

    }
}

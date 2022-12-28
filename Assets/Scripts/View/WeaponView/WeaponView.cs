using UnityEngine;

namespace PixelGame.View
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _attackDelay;

        public float Damage { get => _damage; }
        public float AttackDelay { get => _attackDelay; }
    }
}

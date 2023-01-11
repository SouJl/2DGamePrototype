using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IWeapon
    {
        float Damage { get; set; }

        float AttackDelay { get; set; }

        void Update(float time);

        void Attack(Vector3 target);
    }
}

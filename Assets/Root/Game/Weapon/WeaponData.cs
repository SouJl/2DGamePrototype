using UnityEngine;

namespace Root.PixelGame.Game.Weapon
{
    internal interface IWeaponData
    {
        float Damage { get; }
        int MaxCombo { get; }
    }

    [CreateAssetMenu(fileName = nameof(WeaponData), menuName = "Configs/" + nameof(WeaponData))]
    internal class WeaponData : ScriptableObject, IWeaponData
    {
        [field: SerializeField] public float Damage { get; private set; } = 10f;

        [field: SerializeField] public int MaxCombo { get; private set; } = 2;


    }
}

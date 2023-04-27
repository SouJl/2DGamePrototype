using System.Collections.Generic;
using UnityEngine;

namespace Root.PixelGame.Game.Weapon
{
    internal interface IWeaponData
    {
        IList<IAttackData> Attacks { get; }
    }

    [CreateAssetMenu(fileName = nameof(WeaponData), menuName = "Configs/" + nameof(WeaponData))]
    internal class WeaponData : ScriptableObject, IWeaponData
    {
        [SerializeField] public AttackData[] _attacks;

        public IList<IAttackData> Attacks => _attacks;
    }
}

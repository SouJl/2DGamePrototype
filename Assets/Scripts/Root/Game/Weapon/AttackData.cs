using System;
using UnityEngine;

namespace Root.PixelGame.Game.Weapon
{
    internal interface IAttackData 
    {
        string AttackName { get; }
        float Damage { get; }
        float KnockbackStrength { get; }
        Vector2 KnockbackAngle { get; }
    }

    [Serializable]
    internal class AttackData : IAttackData
    {
        [field: SerializeField] public string AttackName { get; private set; } = "Attack1";

        [field: SerializeField] public float Damage { get; private set; } = 10f;

        [field: SerializeField] public float KnockbackStrength { get; private set; } = 10f;

        [field: SerializeField] public Vector2 KnockbackAngle { get; private set; }
    }
}

using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IUnit
    {
        ComponentsModel UnitComponents { get; }
        SpriteRenderer SpriteRenderer { get; }

        Vector2 CurrentVelocity { get; set; }
    }
}

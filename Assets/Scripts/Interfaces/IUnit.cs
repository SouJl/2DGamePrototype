using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IUnit
    {
        ComponentsModel UnitComponents { get; }
        SpriteRenderer SpriteRenderer { get; }
        IMove MoveModel { get; }
    }
}

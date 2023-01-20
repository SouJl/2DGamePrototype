using PixelGame.Model;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IUnit
    {
        ComponentsModel UnitComponents { get; }
        SpriteRenderer SpriteRenderer { get; }
        ContactsPollerModel ContactsPoller { get; }
        IMove MoveModel { get; }
    }
}

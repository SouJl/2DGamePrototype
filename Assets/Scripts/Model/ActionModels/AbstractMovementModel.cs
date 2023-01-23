using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractMovementModel : IMove
    {
        private IUnit _unit;

        public IUnit Unit { get => _unit; }

        public AbstractMovementModel(IUnit unit)
        {
            _unit = unit;
        }

        public abstract void Move(Vector2 resultVelocity);
    }
}

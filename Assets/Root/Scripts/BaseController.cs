using PixelGame.Tool;
using UnityEngine;

namespace PixelGame
{
    internal abstract class BaseController : IExecute
    {
        protected readonly float deltaTime;
        protected readonly float fixedTime;

        public BaseController()
        {
            deltaTime = Time.deltaTime;
            fixedTime = Time.deltaTime;
        }

        public abstract void Execute();

        public abstract void FixedExecute();
    }
}

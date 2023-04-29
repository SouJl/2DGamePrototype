using UnityEngine;

namespace PixelGame
{
    internal interface IExecute
    {
        void Execute();

        void FixedExecute();
    }

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

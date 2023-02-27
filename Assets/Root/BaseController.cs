namespace Root.PixelGame
{
    internal interface IExecute
    {
        void Execute();

        void FixedExecute();
    }

    internal abstract class BaseController : IExecute
    {
        public abstract void Execute();

        public abstract void FixedExecute();
    }
}

namespace PixelGame.Game.UI
{
    internal interface IGameElementUI<T>
    {
        void InitUI(T model);

        void DeinitUI();
    }
}

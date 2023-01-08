using PixelGame.View;

namespace PixelGame.Interfaces
{
    public interface IViewService
    {
        T Instantiate<T>(LevelObjectView prefab);

        void Destroy(LevelObjectView gameObject);
    }
}

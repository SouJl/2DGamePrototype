namespace Root.PixelGame.Game.Core
{
    internal interface ICoreFactory<CoreData, CoreType> 
    {
        CoreData GetCore(CoreType type);
    }
}

namespace Root.PixelGame.Game.Enemy
{
    internal class EnemeControllerFactory
    {
        public IExecute CreateEnemyController(IEnemyView view)
        {
            switch (view)
            {
                default:
                    return null;
                case StalkerEnemyView stalkerEnemy: 
                    {
                        return null;
                    }
            }
        }
    }
}

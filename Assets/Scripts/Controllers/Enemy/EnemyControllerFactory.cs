using PixelGame.Interfaces;
using PixelGame.View;

namespace PixelGame.Controllers
{
    public class EnemyControllerFactory
    {
        public IExecute GetEnemyController(EnemyView enemy) 
        {
            switch(enemy)
            {
                default:
                    return null;

                case BatEnemyView batEnemy: 
                    {
                        return new BatEnemyController(batEnemy);
                    }
            }
        }
    }
}

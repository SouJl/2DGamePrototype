using PixelGame.Interfaces;
using PixelGame.View;

namespace PixelGame.Controllers
{
    public class JointsController : IExecute
    {
        private LiftsController _liftsController;

        public JointsController(JointsCollectionView jointsCollection) 
        {
            _liftsController = new LiftsController(jointsCollection.Lifts);
        }

        public void Execute()
        {
            _liftsController.Execute();
        }

        public void FixedExecute()
        {
            _liftsController.FixedExecute();
        }
    }
}

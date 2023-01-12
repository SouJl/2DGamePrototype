using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using System.Collections.Generic;

namespace PixelGame.Controllers
{
    public class LiftsController : IExecute
    {
        private List<LiftModel> _lifts;

        public LiftsController(List<LiftView> liftViews)
        {
            foreach (var lift in liftViews) 
            {
                _lifts.Add(new LiftModel(lift.Joint, lift.Speed));
            }
        }

        public void Execute()
        {
            
        }

        public void FixedExecute()
        {
            
        }
    }
}

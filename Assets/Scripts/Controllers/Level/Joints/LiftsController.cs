using PixelGame.Interfaces;
using PixelGame.Model;
using PixelGame.View;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class LiftsController : IExecute
    {
        private List<LiftModel> _lifts;

        public LiftsController(List<LiftView> liftViews)
        {
            _lifts = new List<LiftModel>();

            foreach (var lift in liftViews) 
            {
                _lifts.Add(new LiftModel(lift, lift.Speed, lift.StayTime));
            }
        }

        public void Execute()
        {
            
        }

        public void FixedExecute()
        {
            foreach(var lift in _lifts)
            {
                lift.Upate(Time.fixedDeltaTime);
            }
        }
    }
}

using UnityEngine;

namespace PixelGame.View
{
    public class LevelMachinesContainerView:MonoBehaviour
    {
        [SerializeField] ElevatorView[] elevatorViews;

        public ElevatorView[] Elevators => elevatorViews;
    }
}

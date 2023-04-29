using UnityEngine;

namespace PixelGame.Game.Items
{
    internal interface ICoinView
    {
        void SetActive(bool state);
    }

    internal class CoinView : MonoBehaviour, ICoinView
    {
        public void SetActive(bool state) 
            => gameObject.SetActive(state);
    }
}

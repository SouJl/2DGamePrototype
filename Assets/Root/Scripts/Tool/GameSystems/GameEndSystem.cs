using PixelGame.Components;
using System;
using System.Collections;
using UnityEngine;

namespace PixelGame.Tool
{
    internal class GameEndSystem : MonoBehaviour
    {
        [SerializeField] private GameEndComponent _gameEndUI;

        public event Action OnEndCallBack;

        public void RestartGame()
        {
            GameSceneLoader.Instance.LoadScene(1);
        }

        public void GameEnd(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                _gameEndUI.ShowGameEndText();
                StartCoroutine(GameExitCoroutine());
            }
        }

        IEnumerator GameExitCoroutine()
        {
            yield return new WaitForSeconds(2f);
            OnEndCallBack?.Invoke();
            GameSceneLoader.Instance.LoadScene(0);
        }
    }
}

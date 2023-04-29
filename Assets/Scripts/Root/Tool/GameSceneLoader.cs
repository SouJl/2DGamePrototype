using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Root.PixelGame.Tool
{
    internal class GameSceneLoader : MonoBehaviour
    {
        public static GameSceneLoader Instance;

        [SerializeField] private float _transitionTime = 2f;
        [SerializeField] private Animator _transition;


        public void Awake()
        {
            if (Instance == null) 
            {
                Instance = this;
                _transition.gameObject.SetActive(true);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(LoadSceneCoroutine(sceneIndex));
        }

        IEnumerator LoadSceneCoroutine(int index)
        {
            _transition.SetTrigger("Start");
            yield return new WaitForSeconds(_transitionTime);
            SceneManager.LoadScene(index);
        }
    }
}

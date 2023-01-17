using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingPlatformComponent : MonoBehaviour
{
    [SerializeField] private float _fallingDelay = 1f;
    [SerializeField] private float _destroyDelay = 3f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Falling());
        }
    }

    IEnumerator Falling() 
    {
        yield return new WaitForSeconds(_fallingDelay);
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, _destroyDelay);
    }
}

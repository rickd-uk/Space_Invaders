
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;

    public float speed;
    public System.Action destroyed;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        // When projectile collides with any object destroy it
        destroyed.Invoke();
        Destroy(gameObject);
    }
}

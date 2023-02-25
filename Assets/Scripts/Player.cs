
using UnityEngine;

public class Player : MonoBehaviour
{
    public Projectile LaserPrefab;

    private bool laserActive;

    public float speed = 5.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!laserActive)
        {
            Projectile Projectile = Instantiate(LaserPrefab, transform.position, Quaternion.identity);
            Projectile.destroyed += LaserDestroyed;
            laserActive = true;
        }
       
    }

    private void LaserDestroyed()
    {
        laserActive = false;
    }
}

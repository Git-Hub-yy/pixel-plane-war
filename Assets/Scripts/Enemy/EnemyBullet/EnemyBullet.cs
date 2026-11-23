
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 6f;

    void Update()
    {
        transform.position += Vector3.down * bulletSpeed * Time.deltaTime;

        if (transform.position.y < -9f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}

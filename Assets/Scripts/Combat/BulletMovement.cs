
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed = 12f;

    void Update()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;

        if (transform.position.y > 9f)
        {
            Destroy(gameObject);
        }
    }
}

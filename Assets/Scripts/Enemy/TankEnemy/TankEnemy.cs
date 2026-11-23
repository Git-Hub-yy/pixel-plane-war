
using UnityEngine;

public class TankEnemy : EnemyBase
{
    public float moveSpeed = 0.5f;

    void Update()
    {
        transform.position += Vector3.down *
            moveSpeed * Time.deltaTime;

        if (transform.position.y < -9f)
        {
            Destroy(gameObject);
        }
    }
}

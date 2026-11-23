
using UnityEngine;

public class AircraftEnemy : EnemyBase
{
    public float moveSpeed = 2f;
    public float horizontalRange = 1f;
    public float waveSpeed = 2f;

    private float startX;
    private float startTime;

    protected override void Start()
    {
        base.Start();

        startX = transform.position.x;
        startTime = Time.time;
    }

    void Update()
    {
        float offset = Mathf.Sin(
            (Time.time - startTime) * waveSpeed
        ) * horizontalRange;

        transform.position += Vector3.down *
            moveSpeed * Time.deltaTime;

        transform.position = new Vector3(
            startX + offset,
            transform.position.y,
            transform.position.z
        );

        if (transform.position.y < -9f)
        {
            Destroy(gameObject);
        }
    }
}


using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("敌人预制体")]
    public GameObject enemyPrefab;
    public GameObject tankPrefab;

    [Header("生成设置")]
    public float spawnInterval = 2f;
    public float spawnY = 8f;

    public float minX = -4f;
    public float maxX = 4f;

    public int maxEnemyCount = 5;

    [Header("坦克生成概率")]
    [Range(0f, 1f)]
    public float tankSpawnChance = 0.2f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemyCount)
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        GameObject selectedPrefab = enemyPrefab;

        // 按概率选择坦克
        if (tankPrefab != null && Random.value < tankSpawnChance)
        {
            selectedPrefab = tankPrefab;
        }

        if (selectedPrefab == null)
        {
            Debug.LogError("没有设置敌人预制体！");
            return;
        }

        float randomX = Random.Range(minX, maxX);

        Vector3 spawnPosition = new Vector3(
            randomX,
            spawnY,
            0f
        );

        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}

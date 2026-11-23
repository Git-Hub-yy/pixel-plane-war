
using UnityEngine;

public class BombProp : MonoBehaviour
{
    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;

            Debug.Log("玩家拾取炸弹，清除所有敌人！");

            ClearAllEnemies();

            Destroy(gameObject);
        }
    }

    private void ClearAllEnemies()
    {
        // 找到场景中所有 Tag 为 Enemy 的敌人
        GameObject[] enemies =
            GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                continue;
            }

            // 通过 EnemyBase 的死亡流程处理敌人
            EnemyBase enemyBase =
                enemy.GetComponent<EnemyBase>();

            if (enemyBase != null)
            {
                enemyBase.TakeDamage(999999);
            }
            else
            {
                Debug.LogWarning(
                    enemy.name + " 没有挂载 EnemyBase，无法正常计算分数和爆炸。"
                );
            }
        }

        Debug.Log("炸弹清除了 " + enemies.Length + " 个敌人！");
    }
}

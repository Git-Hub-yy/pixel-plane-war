
using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour
{
    [Header("敌人属性")]
    public int maxHealth = 2;
    public int scoreValue = 100;

    [Header("道具掉落")]
    public GameObject healthPropPrefab;
    [Range(0f, 1f)]
    public float dropChance = 0.2f;

    public GameObject shieldPropPrefab;
    [Range(0f, 1f)]
    public float shieldDropChance = 0.1f;

    public GameObject bombPropPrefab;

    [Range(0f, 1f)]
    public float bombDropChance = 0.05f;
    protected int currentHealth;
    protected SpriteRenderer spriteRenderer;

    public GameObject explosionPrefab;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 受到伤害
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(HitFlash());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 受击闪烁
    IEnumerator HitFlash()
    {
        if (spriteRenderer == null)
        {
            yield break;
        }

        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.08f);

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }

    // 敌人死亡
    protected virtual void Die()
    {
        // 增加分数
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(scoreValue);
        }

        // 播放爆炸
        if (explosionPrefab != null)
        {
            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );
        }

        // 随机掉落道具
        // 随机掉落三种道具，每次死亡最多掉落一种
        float dropRoll = Random.value;

        if (dropRoll < dropChance)
        {
            if (healthPropPrefab != null)
            {
                Instantiate(healthPropPrefab, transform.position, Quaternion.identity);
            }
        }
        else if (dropRoll < dropChance + shieldDropChance)
        {
            if (shieldPropPrefab != null)
            {
                Instantiate(shieldPropPrefab, transform.position, Quaternion.identity);
            }
        }
        else if (dropRoll < dropChance + shieldDropChance + bombDropChance)
        {
            if (bombPropPrefab != null)
            {
                Instantiate(bombPropPrefab, transform.position, Quaternion.identity);
            }
        }

        Destroy(gameObject);
    }

    // 玩家子弹碰撞
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}

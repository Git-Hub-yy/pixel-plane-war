
using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("生命值设置")]
    public int maxHealth = 3;
    private int currentHealth;

    public TMP_Text healthText;

    [Header("受伤无敌设置")]
    public float invincibleDuration = 1.2f;
    private bool isInvincible = false;

    [Header("护盾设置")]
    public float shieldDuration = 5f;
    public Color shieldColor = new Color(0.2f, 0.8f, 1f, 1f);
    private bool isShielded = false;
    private Coroutine shieldCoroutine;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        // 正在受伤无敌或护盾保护时，不受到伤害
        if (isInvincible || isShielded)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealthUI();

        Debug.Log("玩家受到伤害，剩余生命：" + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("玩家生命归零，游戏结束！");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }

            gameObject.SetActive(false);
            return;
        }

        StartCoroutine(InvincibleEffect());
    }

    // 受伤后的短暂无敌闪烁
    IEnumerator InvincibleEffect()
    {
        isInvincible = true;

        float timer = 0f;

        while (timer < invincibleDuration)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }

            yield return new WaitForSeconds(0.1f);

            timer += 0.1f;
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
            UpdatePlayerColor();
        }

        isInvincible = false;
    }

    // 拾取护盾时调用
    public void ActivateShield(float duration)
    {
        if (shieldCoroutine != null)
        {
            StopCoroutine(shieldCoroutine);
        }

        shieldCoroutine = StartCoroutine(ShieldEffect(duration));
    }

    // 护盾持续效果
    IEnumerator ShieldEffect(float duration)
    {
        isShielded = true;
        UpdatePlayerColor();

        Debug.Log("护盾已激活，持续 " + duration + " 秒");

        yield return new WaitForSeconds(duration);

        isShielded = false;
        shieldCoroutine = null;

        UpdatePlayerColor();

        Debug.Log("护盾效果结束");
    }

    // 根据护盾状态更新玩家颜色
    void UpdatePlayerColor()
    {
        if (spriteRenderer == null)
        {
            return;
        }

        if (isShielded)
        {
            spriteRenderer.color = shieldColor;
        }
        else
        {
            spriteRenderer.color = originalColor;
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "生命值：" + currentHealth;
        }
    }

    // 恢复生命值
    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthUI();

        Debug.Log("玩家恢复生命值：" + currentHealth);
    }
}

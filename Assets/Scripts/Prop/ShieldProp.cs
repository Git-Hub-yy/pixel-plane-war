
using UnityEngine;

public class ShieldProp : MonoBehaviour
{
    public float shieldDuration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth =
                other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.ActivateShield(shieldDuration);

                Debug.Log("玩家拾取了护盾道具！");

                Destroy(gameObject);
            }
        }
    }
}

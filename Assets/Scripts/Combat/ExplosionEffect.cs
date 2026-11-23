
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();

        if (animator != null &&
            animator.runtimeAnimatorController != null)
        {
            float duration = animator.GetCurrentAnimatorStateInfo(0).length;

            Destroy(gameObject, duration);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }
}

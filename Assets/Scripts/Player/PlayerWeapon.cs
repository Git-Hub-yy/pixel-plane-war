
using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour
{
    [Header("射击设置")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireInterval = 0.3f;

    void Start()
    {
        StartCoroutine(AutoFire());
    }

    IEnumerator AutoFire()
    {
        // 等待玩家真正点击开始游戏
        while (GameManager.Instance == null ||
               !GameManager.Instance.IsGameStarted)
        {
            yield return null;
        }

        // 游戏开始后才自动射击
        while (true)
        {
            Fire();

            yield return new WaitForSeconds(fireInterval);
        }
    }

    void Fire()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            return;
        }

        Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );
    }
}

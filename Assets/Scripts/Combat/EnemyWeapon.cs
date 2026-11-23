
using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireInterval = 2f;

    void Start()
    {
        StartCoroutine(AutoFire());
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireInterval);

            if (bulletPrefab != null && firePoint != null)
            {
                Instantiate(
                    bulletPrefab,
                    firePoint.position,
                    Quaternion.identity
                );
            }
        }
    }
}

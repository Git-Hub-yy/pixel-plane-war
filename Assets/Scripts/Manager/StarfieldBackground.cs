
using UnityEngine;

public class StarfieldBackground : MonoBehaviour
{
    [Header("星星预制体")]
    public GameObject starPrefab;

    [Header("星星数量")]
    public int starCount = 40;

    [Header("生成范围")]
    public float minX = -4.3f;
    public float maxX = 4.3f;

    public float minY = -8f;
    public float maxY = 8f;

    [Header("移动速度")]
    public float minSpeed = 0.5f;
    public float maxSpeed = 1.2f;

    private GameObject[] stars;
    private float[] starSpeeds;

    void Start()
    {
        if (starPrefab == null)
        {
            Debug.LogError("没有设置 Star Prefab！");
            return;
        }

        stars = new GameObject[starCount];
        starSpeeds = new float[starCount];

        // 随机生成星星
        for (int i = 0; i < starCount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            Vector3 position = new Vector3(
                randomX,
                randomY,
                0f
            );

            stars[i] = Instantiate(
                starPrefab,
                position,
                Quaternion.identity,
                transform
            );

            starSpeeds[i] = Random.Range(
                minSpeed,
                maxSpeed
            );
        }
    }

    void Update()
    {
        if (stars == null)
        {
            return;
        }

        for (int i = 0; i < stars.Length; i++)
        {
            if (stars[i] == null)
            {
                continue;
            }

            // 星星向下移动
            stars[i].transform.Translate(
                Vector3.down * starSpeeds[i] * Time.deltaTime,
                Space.World
            );

            // 超出屏幕后回到顶部
            if (stars[i].transform.position.y < minY)
            {
                float randomX = Random.Range(minX, maxX);

                stars[i].transform.position = new Vector3(
                    randomX,
                    maxY,
                    0f
                );
            }
        }
    }
}

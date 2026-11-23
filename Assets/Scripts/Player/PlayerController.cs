
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 15f;

    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 targetPosition;

    private float minX = -4.1f;
    private float maxX = 4.1f;
    private float minY = -7.2f;
    private float maxY = 7.2f;

    void Start()
    {
        mainCamera = Camera.main;
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleInput();

        if (isDragging)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );
        }
    }

    void HandleInput()
    {
        // 手机触屏
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                TryStartDrag(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved ||
                     touch.phase == TouchPhase.Stationary)
            {
                if (isDragging)
                {
                    UpdateTargetPosition(touch.position);
                }
            }
            else if (touch.phase == TouchPhase.Ended ||
                     touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }
        // 电脑鼠标测试
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                TryStartDrag(Input.mousePosition);
            }

            if (Input.GetMouseButton(0) && isDragging)
            {
                UpdateTargetPosition(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
        }
    }

    void TryStartDrag(Vector2 screenPosition)
    {
        Vector3 worldPosition = ScreenToWorld(screenPosition);

        if (Vector2.Distance(worldPosition, transform.position) < 1.2f)
        {
            isDragging = true;
        }
    }

    void UpdateTargetPosition(Vector2 screenPosition)
    {
        Vector3 worldPosition = ScreenToWorld(screenPosition);

        targetPosition = new Vector3(
            Mathf.Clamp(worldPosition.x, minX, maxX),
            Mathf.Clamp(worldPosition.y, minY, maxY),
            transform.position.z
        );
    }

    Vector3 ScreenToWorld(Vector2 screenPosition)
    {
        Vector3 position = new Vector3(
            screenPosition.x,
            screenPosition.y,
            -mainCamera.transform.position.z
        );

        return mainCamera.ScreenToWorldPoint(position);
    }
}

using UnityEngine;

/// <summary>
/// 按 ESC 退出游戏，并让播放器以无边框全屏启动。
/// 用 RuntimeInitializeOnLoadMethod 自动注入，不需要挂到场景里的任何物体上。
/// </summary>
public static class EscQuit
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
#if !UNITY_EDITOR
        // 启动时切成无边框全屏，避免窗口化时四周露出桌面
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
#endif
        var go = new GameObject("EscQuit");
        Object.DontDestroyOnLoad(go);
        go.AddComponent<EscQuitBehaviour>();
    }
}

public class EscQuitBehaviour : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
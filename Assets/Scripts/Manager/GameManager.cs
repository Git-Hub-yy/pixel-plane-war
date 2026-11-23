
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("游戏界面")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    private bool isGameOver = false;
    private bool isStarted = false;
    private bool isPaused = false;
    public GameObject gameplayHUD;

    public bool IsGameStarted => isStarted;
    public bool IsGamePaused => isPaused;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    void Start()
    {
        isStarted = false;
        isPaused = false;
        isGameOver = false;

        if (startPanel != null)
        {
            startPanel.SetActive(true);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        if (gameplayHUD != null)
        {
            gameplayHUD.SetActive(false);
        }

        Time.timeScale = 0f;
    }

    // 开始游戏
    public void StartGame()
    {
        if (isStarted || isGameOver) return;

        isStarted = true;

        if (startPanel != null)
        {
            startPanel.SetActive(false);
        }
        if (gameplayHUD != null)
        {
            gameplayHUD.SetActive(true);
        }

        Time.timeScale = 1f;
    }

    // 暂停游戏
    public void PauseGame()
    {
        if (!isStarted || isGameOver || isPaused)
        {
            return;
        }

        isPaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }

        Debug.Log("游戏已暂停");
    }

    // 继续游戏
    public void ResumeGame()
    {
        if (!isPaused || isGameOver)
        {
            return;
        }

        isPaused = false;

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        Time.timeScale = 1f;

        Debug.Log("游戏继续");
    }

    // 游戏结束
    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        isPaused = false;

        Time.timeScale = 0f;

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    // 重新开始
    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Canvas Pause;
    public Canvas GameOver;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI FinalText;

    public void Start()
    {
        Pause.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
        Pause.enabled = false;
        GameOver.enabled = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause.enabled)
            {
                Debug.Log("Game Resumed");
                ResumeGame();
            }
            else
            {
                Debug.Log("Game Paused");
                PauseGame();
            }
        }
        if (GameManager.Instance.Lives <= 0)
        {
            GameOverMenu();
        }
        ScoreText.text = "Score: " + GameManager.Instance.score;
        LivesText.text = "Lives: " + GameManager.Instance.Lives;
    }

    private void PauseGame()
    {
        Pause.enabled = true;
        Pause.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Pause.enabled = false;
        Pause.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOverMenu()
    {
        GameOver.enabled = true;
        GameOver.gameObject.SetActive(true);
        FinalText.text = "Game Over\nFinal Score: " + GameManager.Instance.score;
        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameOver.enabled = false;
        GameOver.gameObject.SetActive(false);
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

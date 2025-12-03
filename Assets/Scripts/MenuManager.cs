using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


//second menu script here
//yeah this is the bulk of the menu logic
//each function does almost exactly what it says

//this script also manages the texts and some of the UI elements

public class MenuManager : MonoBehaviour
{
    public Canvas NextLevel;
    public Canvas Pause;
    public Canvas GameOver;
    public TextMeshProUGUI NextLevelText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI FinalText;

    public void Start()
    {
        NextLevel.gameObject.SetActive(false);
        Pause.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
        NextLevel.enabled = false;
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
        if(GameManager.Instance.enemies <= 0)
        {
            NextLevelMenu();
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
    public void NextLevelMenu()
    {
        NextLevel.enabled = true;
        NextLevel.gameObject.SetActive(true);
        NextLevelText.text = "Level Complete!\nFinal Score: " + GameManager.Instance.score;
        Time.timeScale = 0f;
        
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

    public void NextLevelLoad()
    {
        Time.timeScale = 1f;
        NextLevel.enabled = false;
        NextLevel.gameObject.SetActive(false);
        SceneManager.LoadScene("Level02");
        GameManager.Instance.ResetGame();
    }

    public void MainMenuLoad()
    {
        Time.timeScale = 1f;
        NextLevel.enabled = false;
        NextLevel.gameObject.SetActive(false);
        DestroyPersistentObjects();
        SceneManager.LoadScene("Main_Menu");
    }


    private void DestroyPersistentObjects()
    {
        //this function destroys all persistent objects
        //this will only be called when going back to the main menu
        //this allows for a fresh start when the game is finished

        var temp = new GameObject("Temp");
        DontDestroyOnLoad(temp);
        foreach (var obj in temp.scene.GetRootGameObjects())
        {
            if (obj.name != "Temp")
            {
                Destroy(obj);
            }
        }
        Destroy(temp);
    }




}

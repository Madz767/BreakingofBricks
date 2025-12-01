using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Level01");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}

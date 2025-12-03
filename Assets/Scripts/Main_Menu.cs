using UnityEngine;
using UnityEngine.SceneManagement;

//I didn't want to put so much into one menu like i did before
// so I split it up into two different scripts

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

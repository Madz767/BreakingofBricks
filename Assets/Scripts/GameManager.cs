using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public int Lives = 3;
    public GameObject Ball;
    public GameObject Shield;
    public Transform Ball_Spawner;
    


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Lives = 3;
        Shield.SetActive(false);
        Ball.transform.position = Ball_Spawner.position;
        Ball.transform.parent = Ball_Spawner;
    }

   

    public bool LostBall()
    {
        Lives--;
        if (Lives > 0)
        {
            //respawns the ball
            return true;
        }
        else
        {
            //you have died
            GameOver();
            return false;
        }
    }


    //here are my power up functions
    public void AddLife()
    {
        if (Lives < 3)
        {
            Lives++;
        }
    }

    public void Poision()
    {
        Lives--;
    }
    

    public void ActivateShield()
    {
        Shield.SetActive(true);
        StartCoroutine(ShieldTimer());
    }
    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(4);
        Shield.SetActive(false);
    }


    private void GameOver()
    {

        


    }

}

using System.Collections;
using UnityEngine;


//this is the game manager, most of my game logic is within


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    
    public int score;
    public int Lives;
    public int enemies;
    public GameObject Ball;
    public GameObject Shield;
    public Transform Ball_Spawner;
    public Transform Shield_Spawn;



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
        //setting the time, health, and amount of enemies
        Time.timeScale = 1f;
        Lives = 3;
        enemies = 15;

        //creating the ball
        Instantiate(Ball, Ball_Spawner.position, Quaternion.identity);
        Ball.transform.parent = Ball_Spawner;

        //hiding the shield
        Shield.transform.parent = null;
        Shield.SetActive(false);
        

        //testing initialization
        Debug.Log(score);
        Debug.Log(Lives);
        Debug.Log(enemies);
    }

    public void ResetGame()
    {
        enemies = 15;
        //score = 0;
        Lives = 3;
        Shield.SetActive(false);
        Ball.transform.position = Ball_Spawner.position;
        Ball.transform.parent = Ball_Spawner;
        Debug.Log(enemies);
    }

    public bool LostBall()
    {
        
        if (Lives > 0)
        {
            //respawns the ball
            Debug.Log(Lives);
            return true;
        }
        return false;
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
        Debug.Log("Shield Activated");
        Shield.SetActive(true);
        StartCoroutine(ShieldTimer());
    }

    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(4);
        Shield.SetActive(false);
    }


    public void AddScore(int points)
    {
        score += points;
        Debug.Log(score);
    }

    public void EnemyDefeated()
    {
        enemies--;
        Debug.Log("Enemies Left: " + enemies);
        if (enemies <= 0)
        {
            Debug.Log("All Enemies Dead");
            Time.timeScale = 0f;
        }
    }

}

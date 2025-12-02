using UnityEngine;

public class Brick_Power : MonoBehaviour
{
    public int scoreValue;
    public int BrickHP;
    public GameObject PowerUp;

    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && BrickHP == 1)
        {
            int r = Random.Range(0, 2);
            if (r == 1)
            {
                Instantiate(PowerUp, transform.position, Quaternion.identity);
            }
            
            GameManager.Instance.EnemyDefeated();
            GameManager.Instance.AddScore(scoreValue);
            Debug.Log(GameManager.Instance.enemies);
            Debug.Log("Score Added");
            Destroy(gameObject);
        }
        else
        {
            BrickHP--;
        }
    }



}

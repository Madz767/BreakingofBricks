using UnityEngine;

public class Ball_Movement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private bool isLaunched = false;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        gameObject.transform.parent = GameManager.Instance.Ball_Spawner;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isLaunched && Input.GetKeyDown(KeyCode.Space))
        {
           LaunchBall();
        }

        if (isLaunched && rb.linearVelocity.magnitude < 0.5f)
        {
            // my check to make sure the ball doesn't stop moving
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
    }

    private void LaunchBall()
    {
        isLaunched = true;
        transform.parent = null;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.linearVelocity = Vector2.up * speed;
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this code avoids having the ball just having perfect bounces and adds some randomness to it
        Vector2 vel = rb.linearVelocity;

        if (Mathf.Abs(vel.x) < 0.25f)
        {
            vel.x = vel.x < 0 ? -0.6f : 0.6f;
        }
        if (Mathf.Abs(vel.y) < 0.1f)
        {
            vel.y = vel.y < 0 ? -0.6f : 0.6f;
        }

        //this is used to maintain consistent speed
        rb.linearVelocity = vel.normalized * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            //why couldn't you catch the ball
            
            if(GameManager.Instance.LostBall())
            {                 
                ResetBall();
            }
            
        }
    }

    public void ResetBall()
    {
        isLaunched = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;
        transform.parent = GameManager.Instance.Ball_Spawner;
        transform.position = GameManager.Instance.Ball_Spawner.position;
    }
}



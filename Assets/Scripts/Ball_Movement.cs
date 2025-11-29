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
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.linearVelocity = Vector2.up * speed;
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this code avoids having the ball just having perfect bounces and adds some randomness to it
        Vector2 vel = rb.linearVelocity;

        if (Mathf.Abs(vel.x) < 0.1f)
        {
            vel.x = vel.x < 0 ? -0.3f : 0.3f;
        }
        if (Mathf.Abs(vel.y) < 0.1f)
        {
            vel.y = vel.y < 0 ? -0.3f : 0.3f;
        }

        //this is used to maintain consistent speed
        rb.linearVelocity = vel.normalized * speed;

    }
}

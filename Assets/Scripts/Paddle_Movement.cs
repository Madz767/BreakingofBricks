using UnityEngine;

public class Paddle_Movement : MonoBehaviour
{

    public float speed;
    private float sideInput;

    private Rigidbody2D rb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }


    private void movement()
    {
        sideInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(sideInput * speed, 1);
    }




}

using UnityEngine;

//the paddle is pretty simple only going back and forth
public class Paddle_Movement : MonoBehaviour
{
    public static Paddle_Movement Instance;

    public float speed;
    private float sideInput;

    private Rigidbody2D rb;

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


        //I was adding a debug through the Q key to check certain things during runtime

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    GameManager.Instance.enemies = 0;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heal"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.AddLife();
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.ActivateShield();
        }
        else if (collision.gameObject.CompareTag("Poison"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.Poision();
        }
    }
}




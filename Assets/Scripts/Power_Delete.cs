using UnityEngine;

public class Power_Delete : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }   
    }
}

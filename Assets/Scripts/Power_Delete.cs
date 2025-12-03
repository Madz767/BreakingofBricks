using UnityEngine;

public class Power_Delete : MonoBehaviour
{
    //... pretty barren huh... yeah this is all i needed here
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            Destroy(gameObject);
        }   
    }
}

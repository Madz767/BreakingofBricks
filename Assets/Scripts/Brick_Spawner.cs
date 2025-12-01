using UnityEngine;

public class Brick_Spawner : MonoBehaviour
{

    public GameObject brick1;
    public GameObject brick2;
    public GameObject brick3;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int r = Random.Range(1, 4);

        if (r == 1)
        {
            Instantiate(brick1, transform.position, Quaternion.identity);
        }
        else if (r == 2)
        {
            Instantiate(brick2, transform.position, Quaternion.identity);
        }
        else if (r == 3)
        {
            Instantiate(brick3, transform.position, Quaternion.identity);
        }
    }

   




}

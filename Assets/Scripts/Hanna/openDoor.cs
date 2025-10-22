using UnityEngine;

public class openDoor : MonoBehaviour
{
    //Varibles
    [SerializeField] float speed = 50f;
    [SerializeField] float startRotation = 90f; // door y axis starts out at 90 when closed
    [SerializeField] float endRotation = 10f; // door y axis ends up at 10 when open
    [SerializeField] bool doorOpen = false; // door starts out closed
    [SerializeField] private GameObject door ;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }


    // When object (player) intercepts trigger box
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (doorOpen)
            {
                door.transform.Rotate(0, startRotation, 0, Space.Self);

                doorOpen = false;
            }

            else if (!doorOpen)
            {
                door.transform.Rotate(0, endRotation, 0, Space.Self);

                doorOpen = true;
            }
        }
    }


    // When object (player) leaves trigger box
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

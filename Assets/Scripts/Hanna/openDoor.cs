using UnityEngine;
using UnityEngine.Events;

public class openDoor : MonoBehaviour
{
    //Varibles
    [SerializeField] private GameObject door;
    [SerializeField] private UnityEvent onOpen;
    [SerializeField] private UnityEvent onClose;
    GameObject player;
    AudioSource doorSound;
    bool isOpen;
    [SerializeField] float playerDistance = 0.01f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorSound = GetComponent<AudioSource>();
        isOpen = false;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (!isOpen)
        {
            player = other.gameObject;
            onOpen.Invoke();
            doorSound.Play();
            isOpen = true;

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            onClose.Invoke();
            isOpen = false;

        }
            
    }
}


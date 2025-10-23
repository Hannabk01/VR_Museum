using UnityEngine;
using UnityEngine.Events;

public class buttonProximityChecker : MonoBehaviour
{
    //Variables:
    [SerializeField] private GameObject button;
    [SerializeField] private UnityEvent onPress;
    [SerializeField] private UnityEvent onRelease;
    GameObject presser;
    AudioSource buttonSound;
    bool isPressed;
    float pressedDistance = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
        isPressed = false;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.Translate(Vector3.up * -pressedDistance, Space.Self);
            presser = other.gameObject;
            onPress.Invoke();
            buttonSound.Play();
            isPressed = true;
            Debug.Log("Works!");

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.Translate(Vector3.up * pressedDistance, Space.Self);
            onRelease.Invoke();
            isPressed = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
      

    }


}




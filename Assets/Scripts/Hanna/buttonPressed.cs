using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.Events;

public class buttonPressed : MonoBehaviour
{
    //Variables:
    [SerializeField] private GameObject button;
    [SerializeField] private UnityEvent onPress;
    [SerializeField] private UnityEvent offPress;
    GameObject presser;
    AudioSource buttonSound;
    bool isPressed;
    [SerializeField] float pressedDistance = 0.01f;
    private int timesPressed;

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
            buttonSound.Play();
            isPressed = true;
            timesPressed = timesPressed + 1;

            if (timesPressed % 2 == 0) // is the number even
            {
             offPress.Invoke();
            }
            else // is the number odd
            {
             onPress.Invoke();
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.Translate(Vector3.up * pressedDistance, Space.Self);
            
            isPressed = false;
        }
    }


}




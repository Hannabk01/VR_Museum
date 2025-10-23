using UnityEngine;
using UnityEngine.Events;

public class telegraphKeyPressed : MonoBehaviour
{
    //Variables:
    [SerializeField] private GameObject button;
    [SerializeField] private UnityEvent onPress;
    [SerializeField] private UnityEvent onRelease;
    GameObject presser;
    AudioSource buttonSound;
    bool isPressed;
    [SerializeField] float pressedDistance = 90f;

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
            button.transform.Rotate(-pressedDistance, 0.0f, 0.0f, Space.Self);
            presser = other.gameObject;
            onPress.Invoke();
            buttonSound.Play();
            isPressed = true;

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.Rotate(pressedDistance, 0.0f, 0.0f, Space.Self);
            onRelease.Invoke();
            isPressed = false;
        }
    }


}
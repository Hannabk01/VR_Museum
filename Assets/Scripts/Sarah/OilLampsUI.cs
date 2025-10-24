using UnityEngine;
using UnityEngine.Events;

public class OilLampsUI : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    private void OnTriggerEnter(Collider other)
    {
        onTriggerExit.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerEnter.Invoke();
    }
}

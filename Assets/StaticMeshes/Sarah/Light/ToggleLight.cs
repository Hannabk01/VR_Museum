using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    [SerializeField] GameObject ToggleLightLight;
    private bool ToggleLightActive = false;

    private void Start()
    {
        ToggleLightLight.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (ToggleLightActive == false)
            {
                ToggleLightLight.gameObject.SetActive(true);
                ToggleLightActive = true;

            }
            else
            {
                ToggleLightLight.gameObject.SetActive(false);
                ToggleLightActive = false;
            }
        }
    }
}

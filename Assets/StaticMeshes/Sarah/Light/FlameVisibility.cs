using UnityEngine;

public class FlameVisibility : MonoBehaviour
{
    [SerializeField] GameObject ToggleFlame;
    private bool ToggleFlameActive = false;

    private void Start()
    {
        ToggleFlame.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            if (ToggleFlameActive == false)
            {
                ToggleFlame.gameObject.SetActive(true);
                ToggleFlameActive = true;

            }
            else
            {
                ToggleFlame.gameObject.SetActive(false);
                ToggleFlameActive = false;
            }
        }
    }
}

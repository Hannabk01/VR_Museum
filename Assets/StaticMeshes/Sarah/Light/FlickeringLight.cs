using Newtonsoft.Json.Bson;
using System.CodeDom;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlickeringLight : MonoBehaviour

{
    private Light lightToFlicker;
    [SerializeField, Range(0f, 3f)] private float minIntensity = 0.5f;
    [SerializeField, Range(0f, 3f)] private float maxIntensity = 1.2f;
    [SerializeField, Min(0f)] private float timebetweenIntensity = 0.1f;

    private float currentTimer;
    private void Awake()
    {
        if (lightToFlicker == null)
        {
            lightToFlicker = GetComponent<Light>();
        }

        OnValidate();
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;
        if (!(currentTimer > timebetweenIntensity)) return;
        lightToFlicker.intensity = Random.Range(minIntensity, maxIntensity);
        currentTimer = 0;
    }

    private void OnValidate()
    {
        if(!(minIntensity <= maxIntensity))
        {
            return;
        }
        Debug.LogWarning("Min Intensity is Greater than Max Intensity, swapping values!");
        (minIntensity, maxIntensity) = (maxIntensity, minIntensity);
    }
}

   
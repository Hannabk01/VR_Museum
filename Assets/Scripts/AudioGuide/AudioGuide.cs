using UnityEngine;
using System;

[Serializable]
public class AudioGuideObj
{
    public GameObject aGGameObject;
    public AudioClip aGAudioClip;
    public Material aGMaterial;
}

public class AudioGuide : MonoBehaviour
{
    [SerializeField] GameObject laserObj;
    LineRenderer laserLine;
    [SerializeField] GameObject audioSourceObj;
    AudioSource guideAudioSource;
    GameObject pointingAtObj;
    GameObject selectedObj;
    int selectedObjIndex = 0;
    [SerializeField] AudioGuideObj[] audioGuideObjects;
    Material[] audioGuideObjMaterials;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        laserLine = laserObj.GetComponent<LineRenderer>();
        guideAudioSource = audioSourceObj.GetComponent<AudioSource>();
        laserObj.SetActive(false);

        audioGuideObjMaterials = new Material[audioGuideObjects.Length];
        for (int i = 0; i < audioGuideObjects.Length; i++)
        {
            //audioGuideObjMaterials[i] = audioGuideObjects[i].aGGameObject.GetComponent<MeshRenderer>().material;
            audioGuideObjMaterials[i] = audioGuideObjects[i].aGMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            laserObj.SetActive(true);
            UpdateSelectMaterials();
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            GetObjectLaserPointer();
            
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            PlaySelectedAudio();
            DeselectMaterials();
            laserObj.SetActive(false);
        }
        
    }

    void GetObjectLaserPointer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, gameObject.transform.forward, out hit, 100))
        {
            laserLine.SetPosition(0, gameObject.transform.position);
            laserLine.SetPosition(1, hit.point);
            if (hit.transform.gameObject != pointingAtObj)
            {
                
                pointingAtObj = hit.transform.gameObject;
                selectedObjIndex = 0;
                for (int i = 0; i < audioGuideObjects.Length; i++)
                {
                    
                    if (pointingAtObj == audioGuideObjects[i].aGGameObject)
                    {
                        selectedObj = hit.transform.gameObject;
                        selectedObjIndex = i+1;
                        guideAudioSource.clip = audioGuideObjects[i].aGAudioClip;
                    }
                }
                UpdateSelectMaterials();
            }
        }
        else
        {
            laserLine.SetPosition(0, gameObject.transform.position);
            laserLine.SetPosition(1, gameObject.transform.position + (gameObject.transform.forward * 100));
            pointingAtObj = null;
            selectedObjIndex = 0;
            UpdateSelectMaterials();
        }
    }

    void PlaySelectedAudio()
    {
        if (pointingAtObj == selectedObj)
        {
            guideAudioSource.Play();
        }
        else
        {
            guideAudioSource.Stop();
        }
    }
    void UpdateSelectMaterials()
    {
        for (int i = 0; i < audioGuideObjMaterials.Length; i++)
        {
            if (pointingAtObj != null && i == selectedObjIndex-1)
            {
                audioGuideObjMaterials[i].SetColor("_EmissionColor", Color.red);
            }
            else
            {
                audioGuideObjMaterials[i].SetColor("_EmissionColor", Color.white);
            }
        }
    }

    void DeselectMaterials()
    {
        for (int i = 0; i < audioGuideObjMaterials.Length; i++)
        {
            audioGuideObjMaterials[i].SetColor("_EmissionColor", Color.black);
        }
    }
}

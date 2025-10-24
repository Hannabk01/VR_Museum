using UnityEngine;
using System;

[Serializable]
public class AudioGuideObj
{
    public GameObject aGGameObject;
    public AudioClip aGAudioClip;
}

public class AudioGuide : MonoBehaviour
{
    [SerializeField] GameObject laserObj;
    LineRenderer laserLine;
    [SerializeField] GameObject audioSourceObj;
    AudioSource guideAudioSource;
    GameObject pointingAtObj;
    GameObject selectedObj;
    int selectedObjIndex;
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
            audioGuideObjMaterials[i] = audioGuideObjects[i].aGGameObject.GetComponent<MeshRenderer>().material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            laserObj.SetActive(true);
            UpdateSelectMaterials();
        }
        if (Input.GetButton("Jump"))
        {
            GetObjectLaserPointer();
            
        }
        if (Input.GetButtonUp("Jump"))
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
                for (int i = 0; i < audioGuideObjects.Length; i++)
                {
                    if (pointingAtObj == audioGuideObjects[i].aGGameObject)
                    {
                        selectedObj = hit.transform.gameObject;
                        selectedObjIndex = i;
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
            if (pointingAtObj != null && i == selectedObjIndex)
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

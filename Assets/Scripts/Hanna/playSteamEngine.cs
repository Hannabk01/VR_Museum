using System;
using UnityEngine;
using UnityEngine.Events;

public class playSteamEngine : MonoBehaviour
{

    //Variables
    [SerializeField] private Animator animatedMesh;
    [SerializeField] private string stateName = "SteamEngineON";
    private bool play;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        animatedMesh = GetComponent<Animator>();
        animatedMesh.Play(stateName, 0, 0.0f);

    }


}

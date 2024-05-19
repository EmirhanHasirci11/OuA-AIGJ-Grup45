using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressuregameObject : MonoBehaviour
{


    private Vector3 originalPosition;
    [SerializeField] private float downValue=0.1f; 
    

    void Start()
    {        
        originalPosition = gameObject.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - downValue, gameObject.transform.position.z);
        }
    }

    void OnTriggerExit(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            gameObject.transform.position = originalPosition;
        }
    }
}

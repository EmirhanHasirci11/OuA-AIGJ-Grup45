using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressuregameObject : MonoBehaviour
{


    private Vector3 originalPosition;
    private Quaternion originalPositionOfDoor;
    [SerializeField] private float downValue=0.1f;
    [SerializeField] GameObject door;
    

    void Start()
    {        
        originalPosition = gameObject.transform.position;
        originalPositionOfDoor = door.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - downValue, gameObject.transform.position.z);
            door.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
    }

    void OnTriggerExit(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            gameObject.transform.position = originalPosition;
            door.transform.rotation = originalPositionOfDoor;
        }
    }
}

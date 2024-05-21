using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] public List<GameObject> Requirements = new List<GameObject>();
    [SerializeField] private GameObject doorPivot;
    private bool isOpened = false;    
    void Update()
    {
        if(Requirements.Count == 0 && !isOpened) 
        { 
            doorPivot.transform.rotation= Quaternion.Euler(new Vector3(0, 90, 0));
            isOpened = true;        
        }
        Debug.Log(doorPivot.gameObject.name +" "+Requirements.Count);
        Debug.Log(Requirements.Count);
    }
}

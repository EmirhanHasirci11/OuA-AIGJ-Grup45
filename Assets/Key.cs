using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Target;
    private Door script;
    private void Start()
    {
       script = Target.GetComponent<Door>();        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            script.Requirements.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalController : MonoBehaviour
{
    public Transform portalPoint;
    public Transform portalPoint2;
    private static bool isTransfer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isTransfer == false)
            {
                other.transform.position = portalPoint.transform.position;
                other.transform.rotation = portalPoint.transform.rotation;
                isTransfer = true;
            }
            else if (isTransfer == true)
            {
                other.transform.position = portalPoint2.transform.position;
                other.transform.rotation = portalPoint2.transform.rotation;
                isTransfer = false;
            }
        }
    }
}

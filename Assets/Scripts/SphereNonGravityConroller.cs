using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereNonGravityConroller : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("STAY");
        other.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT");
        other.GetComponent<Rigidbody>().useGravity = true;
    }
}

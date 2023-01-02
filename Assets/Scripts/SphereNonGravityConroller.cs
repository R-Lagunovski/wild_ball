using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereNonGravityConroller : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = true;
    }
}

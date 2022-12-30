using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public float Power;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody)
        {
            Debug.Log("PUNCH");
            Vector3 direction = collision.transform.position - transform.position;

            collision.rigidbody.AddForce(direction.normalized * Power, ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCelindersController : MonoBehaviour
{
    public float Power;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Bounce");

            Vector3 direction = collision.gameObject.GetComponent<Transform>().position - transform.position;

            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * Power, ForceMode.Impulse);
        }
    }
}

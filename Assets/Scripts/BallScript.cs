using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float Power;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1) * Power, ForceMode.Impulse);
    }
}

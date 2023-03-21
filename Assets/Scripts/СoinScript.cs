using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СoinScript : MonoBehaviour
{

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Collect");
        Destroy(gameObject, 0.6f);
    }
}

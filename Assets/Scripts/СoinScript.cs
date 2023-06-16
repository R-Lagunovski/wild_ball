using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СoinScript : MonoBehaviour
{
    [SerializeField] ParticleSystem ParticleSys;
    private Animator anim;
    private ParticleSystem ps;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Collect");
        ParticleSys.Play(); 
        Destroy(gameObject, 1f);
    }
}

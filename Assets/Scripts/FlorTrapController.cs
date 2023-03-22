using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorTrapController : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void NextAnimation()
    {
        anim.SetInteger("AnimNumber", Random.Range(0,3));
    }
}

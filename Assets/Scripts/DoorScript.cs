using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] GameObject CanvasHelper;
    private Animator anim;
    private bool inTrigger;

    void Awake()
    {
        anim = Door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        if (anim.GetBool("Open") == false)
        {
            CanvasHelper.SetActive(true);
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        CanvasHelper.SetActive(false);
        inTrigger = false;
    }

    private void Update()
    {
        if (inTrigger)
            if (Input.GetKeyDown(KeyCode.E))
                anim.SetTrigger("Open");
    }
}

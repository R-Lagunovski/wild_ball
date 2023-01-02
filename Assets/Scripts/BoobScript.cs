using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoobScript : MonoBehaviour
{
    public float Timer;
    public float Radius;
    public float Power;

    void Update()
    {
        TimerMethod();

        if (Timer <= 0)
        {
            onTimerEndAction();
        }
    }

    private void TimerMethod()
    {
        Timer -= Time.deltaTime;
    }

    private void onTimerEndAction()
    {
        Boom();
        Timer = 5;
    }

    public void Boom()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody b in blocks)
        {
            if (Vector3.Distance(transform.position, b.transform.position) <= Radius)
            {
                Vector3 direction = b.transform.position - transform.position;

                b.AddForce(direction.normalized * Power * (Radius - Vector3.Distance(transform.position, b.transform.position)), ForceMode.Impulse);
            }
        }
    }
}

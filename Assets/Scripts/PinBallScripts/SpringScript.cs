using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpringScript : MonoBehaviour
{
    public Transform targetPosition;
    public float speed;
    private Vector3 startPosition;
    public KeyCode stretch;
    private bool stretching = false;

    private GameObject Ball;

    void Start()
    {
        startPosition = transform.position;
        Ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void Update()
    {
        if (Input.GetKeyDown(stretch))
        {
            stretching = !stretching;
        }
        if(stretching)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, Time.deltaTime * speed);
            
            if(transform.position == targetPosition.position)
            {
                Vector3 direction = Ball.GetComponent<Transform>().position - transform.position;

                Ball.GetComponent<Rigidbody>().AddForce(direction.normalized * speed, ForceMode.Impulse);
                transform.position = startPosition;
                stretching = !stretching;
            }
        }
    }
}

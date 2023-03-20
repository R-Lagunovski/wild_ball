using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpringScript : MonoBehaviour
{
    public KeyCode stretch;
    public float force;
    public float power;

    private Rigidbody connectedBody;
    private Rigidbody m_Rigidbody;
    private SpringJoint m_SpringJoint;

    private GameObject Ball;

    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("Ball");
        
        m_Rigidbody = GetComponent<Rigidbody>();
        m_SpringJoint = GetComponent<SpringJoint>();

        Debug.Log("RIGIT BODY = " + m_SpringJoint.connectedBody.GetType() + ' ' + m_SpringJoint.connectedBody.name);
    }

    void Update()
    {
        if (Input.GetKeyDown(stretch))
        {
            Vector3 direction = m_SpringJoint.connectedBody.position - transform.position;
            m_Rigidbody.AddForce(direction.normalized * force, ForceMode.Impulse);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Push");

            Vector3 direction = collision.gameObject.GetComponent<Transform>().position - transform.position;

            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * power, ForceMode.Impulse);
        }
    }
}

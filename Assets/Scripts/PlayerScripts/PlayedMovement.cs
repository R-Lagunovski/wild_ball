using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{
    public class PlayedMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed = 2.0f;
        private Rigidbody playerRigitbody;

        private void Awake()
        {
            playerRigitbody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 movement)
        {
            playerRigitbody.AddForce(movement * speed);
        }

#if UNITY_EDITOR
        [ContextMenu("Reset Values")]
        private void ResetValues()
        {
            speed = 2;
        }
#endif
    }
}


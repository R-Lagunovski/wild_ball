using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayedMovement))]
    [RequireComponent(typeof(GameObject))]
    public class PlayerSctipt : MonoBehaviour
    {
        [SerializeField] private GameObject EventSystem;
        private Vector3 movement;
        private PlayedMovement playerMovement;
        private GameController gameController;

        private Animator anim;
        private Rigidbody rb;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            playerMovement = GetComponent<PlayedMovement>();
            gameController = EventSystem.GetComponent<GameController>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(Constants.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(Constants.VERTICAL_AXIS);
            anim.SetFloat("Velocity", rb.velocity.magnitude);

            movement = new Vector3(horizontal,0, vertical).normalized;
        }

        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movement);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger GameOver before if " + other.gameObject.tag);
            if (other.gameObject.tag == "EndGameTrigger")
            {
                Debug.Log("Trigger GameOver");
                gameController.RestartMenu();
            }

            if (other.gameObject.tag == "Finish")
            {
                Debug.Log("Finish");
                gameController.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }
}
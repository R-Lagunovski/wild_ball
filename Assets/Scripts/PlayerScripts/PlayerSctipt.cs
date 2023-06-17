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
        [SerializeField] private GameObject playerBody;
        [SerializeField] private new ParticleSystem particleSystem;
        private Vector3 movement;
        private PlayedMovement playerMovement;
        private GameController gameController;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            playerMovement = GetComponent<PlayedMovement>();
            gameController = EventSystem.GetComponent<GameController>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(Constants.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(Constants.VERTICAL_AXIS);

            movement = new Vector3(horizontal,0, vertical).normalized;
        }

        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movement);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "EndGameTrigger")
            {
                particleSystem.Play();
                playerBody.SetActive(false);
                rb.constraints = RigidbodyConstraints.FreezePosition;
                gameController.StartRestartCoroutine();

            }

            if (other.gameObject.tag == "Finish")
            {
                gameController.ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }
}
using UnityEngine;

public class TargetsObjectButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private Animator anim;

    private void Awake()
    {
        anim = target.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (anim != null)
        {
            anim.SetTrigger("Start");
        }
    }
}

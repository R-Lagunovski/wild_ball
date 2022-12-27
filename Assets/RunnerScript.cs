using UnityEngine;

public class RunnerScript : MonoBehaviour
{
    public GameObject Stick;

    public bool moving;

    void Update()
    {
        if (moving)
        {
            Stick.SetActive(true);
        }
        else
            Stick.SetActive(false);
    }

    public void Moving()
    {
        moving = !moving;
    }

}

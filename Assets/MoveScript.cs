using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveScript : MonoBehaviour
{
    public GameObject[] TeamRunners;

    public RunnerScript RunnerScript;

    public float speed;
    public bool move;

    private GameObject nextRunner;
    private int currentTargetIndex;
    private GameObject currentRunner;
    public float passDistance;

    void Start()
    {
        currentRunner = TeamRunners[0];
        currentRunner.GetComponent<RunnerScript>().Moving();
        nextRunner = TeamRunners[1];
        currentTargetIndex = 1;
        
    }

    void Update()
    {
        currentRunner.transform.position = Vector3.MoveTowards(currentRunner.transform.position, nextRunner.transform.position, Time.deltaTime * speed);
        currentRunner.transform.LookAt(nextRunner.transform);


        if (Vector3.Distance(currentRunner.transform.position, nextRunner.transform.position) <= passDistance) 
            ChangeTarget();
    }

    private void ChangeTarget()
    {    
        if (currentTargetIndex == TeamRunners.Length - 1)
            currentTargetIndex = 0;
        else
            currentTargetIndex += 1;

        currentRunner.GetComponent<RunnerScript>().Moving();
        currentRunner = nextRunner;
        currentRunner.GetComponent<RunnerScript>().Moving();
        nextRunner = TeamRunners[currentTargetIndex];
    }
}

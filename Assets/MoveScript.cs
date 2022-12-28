using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveScript : MonoBehaviour
{
    public Transform[] TeamRunners;

    public RunnerScript RunnerScript;

    public float speed;
    public bool move;

    private Transform nextRunner;
    private int currentTargetIndex;
    private Transform currentRunner;
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
        currentRunner.position = Vector3.MoveTowards(currentRunner.position, nextRunner.position, Time.deltaTime * speed);
        currentRunner.LookAt(nextRunner.transform);


        if (Vector3.Distance(currentRunner.position, nextRunner.position) <= passDistance) 
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

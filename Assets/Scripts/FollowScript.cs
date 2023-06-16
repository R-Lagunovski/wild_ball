using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField] Transform Player;

    private void Update()
    {
        transform.position = Player.position;
    }
}

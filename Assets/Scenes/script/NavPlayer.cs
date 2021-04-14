using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavPlayer : MonoBehaviour
{
    public NavMeshAgent agent;  // 플레이어

    public void ShowRoad(Vector3 EndingPoint)
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(EndingPoint);
    }
}

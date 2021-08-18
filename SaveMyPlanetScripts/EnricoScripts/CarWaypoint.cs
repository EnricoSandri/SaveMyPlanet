using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarWaypoint : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform[] waypoints;

    int currentWaypoint = 0;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = waypoints[currentWaypoint];
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            currentWaypoint++;

            if (currentWaypoint > waypoints.Length - 1)
            {
                currentWaypoint = 0;
            }

            target = waypoints[currentWaypoint];
            agent.SetDestination(target.position);
            
        }
    }
}


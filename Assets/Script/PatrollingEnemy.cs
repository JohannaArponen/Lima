using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollingEnemy : MonoBehaviour{
    public Transform[] waypoints;
    public float waypointTriggerDistance = 1f;
    int nextWaypoint = 0;
    NavMeshAgent agent;

    void Awake() {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoints[nextWaypoint].position;
    }

    void Update(){
        var d = Vector3.Distance(transform.position, waypoints[nextWaypoint].position);
        //(p2-p1).magnitude
        if(d < waypointTriggerDistance) {
            nextWaypoint++;
            if(nextWaypoint > waypoints.Length - 1) {
                nextWaypoint = 0;
            }
            agent.destination = waypoints[nextWaypoint].position;
        }
    }
}

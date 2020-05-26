using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollingEnemy : MonoBehaviour{
    public Transform[] waypoints;
    public SpriteRenderer sr;
    public float waypointTriggerDistance = 1f;
    int nextWaypoint = 0;
    public float speed = 1f;
    public bool FindPlayer;
    // public NavMeshAgent agent;

    void Awake() {
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.flipX = true;
        //agent = GetComponent<NavMeshAgent>();
    }

    void Start() {
        
        //agent.destination = waypoints[nextWaypoint].position;
    }

    void Update(){
        transform.position = Vector3.MoveTowards(transform.position,
            waypoints[nextWaypoint].position,
            Time.deltaTime * speed);

        var d = Vector3.Distance(transform.position, waypoints[nextWaypoint].position);
        //(p2-p1).magnitude
        if(d < waypointTriggerDistance) {
            nextWaypoint++;
            if(nextWaypoint > waypoints.Length - 1) {
                nextWaypoint = 0;
            }
            //agent.destination = waypoints[nextWaypoint].position;
        }
        if(sr != null) {
            if (waypoints[nextWaypoint].position.x > transform.position.x) {
                sr.flipX = true;
            }
            else {
                sr.flipX = false;
            }
        }
        
    }

    void GiveDamage() {
        if (FindPlayer) {
           if (GameObject.FindGameObjectWithTag("Player")) {
                GetComponent<HealthSystem>().Damaged();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        //FindPlayer = true;
        collider.GetComponent<HealthSystem>().Damaged();
    }
}

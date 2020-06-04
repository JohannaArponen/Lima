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
    private float dirX;

    void Awake() {
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.flipX = true;
    }

    void Start() {
        dirX = -1f;
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
                dirX = 1f;
            }
            else {
                sr.flipX = false;
                dirX = -1f;
            }
        }
        
    }

    void GiveDamage() {
        if (FindPlayer) {
           if (GameObject.FindGameObjectWithTag("Player")) {
                GetComponent<HealthSystem>().Damaged(transform.position);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collisioninfo) {
        //FindPlayer = true;
        if(collisioninfo.tag == "Player") {
            FindObjectOfType<HealthSystem>().Damaged(enemyPos: transform.position);
        }
           // other.GetComponent<HealthSystem>().Damaged();
            // collider.gameObject.name.Equals("Player");
    }

    /*private void OnTriggerExit2D(Collider2D collider) {
        collider.gameObject.name.Equals("Player");
    }*/
}

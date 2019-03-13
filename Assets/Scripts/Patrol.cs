using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

    public Transform pointA;
    public Transform pointB;
    NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = pointA.position;
    }

    void Update() {
        if (agent.transform.position.x == pointA.position.x && agent.transform.position.z == pointA.position.z) {
            agent.SetDestination(pointB.position);
           // print("A");
        }
        if (agent.transform.position.x == pointB.position.x && agent.transform.position.z == pointB.position.z) {
            agent.SetDestination(pointA.position);
            //print("b");
        }
    }
    
}

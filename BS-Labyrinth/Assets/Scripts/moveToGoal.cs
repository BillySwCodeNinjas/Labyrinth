using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveToGoal : MonoBehaviour
{
    public Transform goal1;
    public Transform goal2;
    private Animator animator;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal1.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.hasPath){
            animator.SetBool("isRunning", true);
        } else{
            animator.SetBool("isRunning", false);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Grabable")){
            Destroy(other.gameObject);
            agent.destination = goal2.position;
        }
    }
}

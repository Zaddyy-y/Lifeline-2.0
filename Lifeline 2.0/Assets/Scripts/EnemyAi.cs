using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.VersionControl.Asset;

public class EnemyAi : MonoBehaviour
{

    public enum fatherStates
    {   
        idle,
        chase,
    }

    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent agent;


    private Animator animator;
    public fatherStates currentState;
    public bool changeState= false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();

        currentState= fatherStates.idle;


    }

    // Update is called once per frame
    void Update()
    {
        StateHandler();
    }


    void StateHandler()
    {
        switch (currentState)
        {
            case fatherStates.idle:
                if (EnterChaseState())
                {
                    changeState = true;
                    DuringState(fatherStates.chase);
                }
                break;

            case fatherStates.chase:
                if (CaughtPlayer())
                {
                    changeState = true;
                    DuringState(fatherStates.idle);
                }
                break;
        }
    }

    void DuringState(fatherStates newState)
    {
        if (currentState == newState) return; // to prevent unnecessary transitions;

        currentState = newState;

        switch (currentState)
        {
            case fatherStates.idle:
                IdleState();
                break;

            case fatherStates.chase:
                ChasePlayerState();
                break;

        }

    }

    private void IdleState()
    {
        animator.SetBool("IsWalking", true);
    }

    private void ChasePlayerState()
    {
        agent.SetDestination(player.transform.position);
        animator.SetBool("IsWalking", true);
    }

    private bool EnterChaseState()
    {
        return Vector3.Distance(player.transform.position, agent.transform.position)> 10;
    }

    private bool CaughtPlayer()
    {
        return Vector3.Distance(player.transform.position, agent.transform.position) < 7;
    }
}

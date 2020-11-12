using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;
using UnityStandardAssets.Characters.FirstPerson;

public class NpcController : MonoBehaviour
{
    public enum WanderType { Random, Waypoint};


    public FirstPersonController player;
    public WanderType wanderType = WanderType.Random;
    public float wanderSpeed = 4f;
    public float chaseSpeed = 7f;
    public float fov = 120f;
    public float viewDistance = 10f;
    public float wanderRadius = 3f;
    public Transform[] waypoints;

    private bool isAware = false;
    private Vector3 wanderPoint;
    private NavMeshAgent agent;
    private int waypointIndex = 0;
    private Animator animator;

    
    

    private void Start()
    {
        wanderPoint = RandomWanderPoint();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        if (isAware)
        {
            agent.SetDestination(player.transform.position);
            animator.SetBool("Aware", true);
            agent.speed = chaseSpeed;
        }
        else
        {
            SearchForPlayer();
            Wander();
            animator.SetBool("Aware", false);
            agent.speed = wanderSpeed;
        }
        
    }
    public void SearchForPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(player.transform.position)) < fov / 2f)
        {
            if (Vector3.Distance(player.transform.position,transform.position) < viewDistance)
            {
                RaycastHit hit;
                if (Physics.Linecast(transform.position, player.transform.position, out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }
                }
            }
        }
    }
    public void OnAware()
    {
        isAware = true;
        
    }
    public void Wander()
    {
        if (wanderType == WanderType.Random)
        {
            if (Vector3.Distance(transform.position, wanderPoint) < 0.5f)
            {
                wanderPoint = RandomWanderPoint();
            }
            else
            {
                agent.SetDestination(wanderPoint);
            }
        }
        else
        {
            if (Vector3.Distance(waypoints[waypointIndex].position, transform.position) < 2f)
            {
                if (waypointIndex == waypoints.Length - 1)
                {
                    waypointIndex = 0;
                }
                else
                {
                    waypointIndex++;
                }
            }
            else
            {
                agent.SetDestination(waypoints[waypointIndex].position);
            }
        }
    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navhit;
        NavMesh.SamplePosition(randomPoint, out navhit, wanderRadius, -1);
        return new Vector3(navhit.position.x, transform.position.y, navhit.position.z);
    }

    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Attack", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Attack", false);

    }
}

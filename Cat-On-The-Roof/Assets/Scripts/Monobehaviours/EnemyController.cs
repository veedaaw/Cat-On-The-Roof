using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject[] waypoints;
    int index;
    NavMeshAgent agent;
    Animator anim;
    GameObject player;
    float aggroRange = 5f;
    bool playerIsVisible = false;
    float angleToSeePlayer = 180f;
    [SerializeField]
    private float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        index = Random.Range(0, waypoints.Length-1);
        InvokeRepeating("Patrol", 0f, 10f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Seek();
        anim.SetFloat("Speed", agent.velocity.magnitude);
        speed = agent.velocity.magnitude;
    }

    void Patrol()
    {
        agent.SetDestination(waypoints[index].transform.position);
        if (index != waypoints.Length - 1)
        {
            index++;
        }
        else
            index = 0;
    }

    void Seek()
    {
        if(Vector3.Distance(agent.transform.position, player.transform.position) < aggroRange
            && canSeeTarget())
        {
            agent.SetDestination(player.transform.position);
        }

    }

    bool canSeeTarget()
    {
        Vector3 direction = player.transform.position - agent.transform.position;
        float angle = Vector3.Angle(agent.transform.forward, direction);
        if (angle < angleToSeePlayer)
        {
            playerIsVisible = true;
        }
        return playerIsVisible;
    }

}

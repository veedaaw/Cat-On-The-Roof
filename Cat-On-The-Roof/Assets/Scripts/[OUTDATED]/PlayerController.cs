using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //NavMeshAgent agent;
    Animator anim;


    public float speed = 3f;
    public float rotationSpeed = 70.0f;
    public float currentSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        /*  NavMeshHit closestHit;
          if (NavMesh.SamplePosition(transform.position, out closestHit, 100f, NavMesh.AllAreas))
          {
              transform.position = closestHit.position;
              agent.enabled = true;
          }*/

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");


        //transform.Translate(0, 0, translation);
        //transform.Rotate(0, rotation, 0);

        transform.Translate(0f, 0f, speed * Time.deltaTime * vertical) ;
        transform.Rotate(0f, rotationSpeed * Time.deltaTime * horizontal, 0f);


        currentSpeed = vertical;
  

        if (anim != null)
        {
            anim.SetFloat("CatSpeed", Mathf.Abs(currentSpeed));
        }
        else
        {
            Debug.Log("anim is null");
        }

        //Debug.Log(agent.velocity.magnitude);
        //agent.SetDestination(transform.position + new Vector3(0, rotation,translation));
    }

}

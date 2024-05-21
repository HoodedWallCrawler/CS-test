using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{   
    public NavMeshAgent agent;
    public Transform[] destination;
    public Transform Player;
    Vector3 target;
    int des =0 ;
    int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, target) < 0.5f)
        {
            GoDestination();
        }

    }

    void OnCollisionEnter(Collision otherpart) {
        if (otherpart.gameObject.tag == "Bullet")
        {
            health -= 100;
        }
    }

    void GoDestination()
    {
       target = destination[des].position;
       agent.SetDestination(target);
       des++;
       if(des == destination.Length)
       {
            des = 0 ;
       }

    }

    
}

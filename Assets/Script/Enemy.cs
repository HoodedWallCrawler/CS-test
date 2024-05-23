using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{   
    // Nav Mesh
    public NavMeshAgent agent;
    public float rotationSpeed = 1f;
    Vector3 dir;
    int des =0 ;

    // Transform
    public Transform[] destination;
    public Transform Player;
    public Transform Orientation;
    public Transform Self;
    

    // Find Player
    Vector3 target;
    bool find = false;
    float countdown = 5f;
    public LayerMask Playermask;

    // Attack
    public Transform attackPoint;
    public float spread;
    public GameObject Enemy_bullet;
    bool attack;
    bool alreadyattack = true;
    public float shootForce;
    public float upwardForce;
    bool reset = false;
    // Animation
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDes();
        GoDestination();
        anim.SetBool("finding", true);
    }

    // Update is called once per frame
    void Update()
    {
      

        if (Vector3.Distance(transform.position, target) < 3f)
        {   
            UpdateDes();
            GoDestination();
        }

        
        // Vector3 pos = new Vector3(Self.position.x, Self.position.y + 2f, Self.position.z);
        if (Physics.Raycast(transform.position, Orientation.forward, 10f, Playermask))
        {
           find = true;
           attack = true;
      
        }
        if (attack)
        {
            Attack();
            countdown -= Time.deltaTime;
            if (countdown < 0)
            {
                reset = true;
                find = false;    
                attack = false;
                countdown = 5f;
            }
        }
        if (find)
        {   
            anim.SetBool("finding", false);
            Invoke("Find", 1f);
        }
        if(reset)
        {   
             Debug.Log("Hello");
             Self.LookAt(target);
             GoDestination();
             reset = false;
        }

    }
    

    void GoDestination()
    {   
        
       agent.SetDestination(target);
       Debug.Log(target);
    //    dir = target - transform.position;
    //    dir.y = 0;
    //     //This allows the object to only rotate on its y axis
    //    Quaternion rot = Quaternion.LookRotation(dir);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0);
       
    }

    void UpdateDes()
    {   
        target = destination[des].position; 
        des++;
        if(des == destination.Length)
         {
            des = 0 ;
         }

    }

    void Find()
    {       
            anim.SetBool("finding", true);
            Self.LookAt(Player);
            agent.SetDestination(Player.transform.position);
        
    }

    void Attack()
    {   
        if (alreadyattack == true)
        { 
            Ray ray = new Ray(Self.position, Orientation.forward); //Just a ray through the middle of your current view
            RaycastHit hit;

            //check if ray hits something
        
            Vector3 targetPoint = ray.GetPoint(30);
            //Just a point far away from the player

            //Calculate direction from attackPoint to targetPoint
            Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
        

            //Calculate spread
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            //Calculate new direction with spread
            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

            //Instantiate bullet/projectile
            GameObject currentBullet = Instantiate(Enemy_bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
            //Rotate bullet to shoot direction
            currentBullet.transform.forward = directionWithSpread.normalized;
            //Add forces to bullet
            currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
            currentBullet.GetComponent<Rigidbody>().AddForce(Self.transform.up * upwardForce, ForceMode.Impulse);

        
                alreadyattack = false;
                Invoke("ResetAttack", 0.5f);
        }

    }

    void ResetAttack()
    {
        alreadyattack = true;
    }

    
    

    
}

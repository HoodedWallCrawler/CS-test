
using UnityEngine;
using TMPro;

public class ProjectileGrenade : MonoBehaviour
{
    //bullet 
    public GameObject grenade;

    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float delay = 3f;
    float countdown;
    public float radius;
    public float force;


    //bools
    bool shooting, readyToShoot, reloading;
    bool hasExploded = false;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject ExplodeEffect;
    //bug fixing :D
    public bool allowInvoke = true;
    // Reference
    public GameObject player;
    private float zgun;
    Rigidbody rb;
    SphereCollider sC;
    
    private void Awake()
    {
        readyToShoot = true;
        rb = GetComponent<Rigidbody>();
        sC = GetComponent<SphereCollider>();
    }

    void Start()
    {
        countdown = delay;
    }
    private void Update()
    {   
        if (CameraControll.grenade_equipped)
        {
            MyInput();
        }
    }
    private void MyInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);
        //Shooting
        
        if (readyToShoot && shooting)
        {
            //Set bullets shot to 0
            Shoot();
            Invoke("Explode", 3f);
        }
        
       
    }

    private void Shoot()
    {
        readyToShoot = false;
        transform.SetParent(null);
        rb.isKinematic = false;
        sC.isTrigger = false;
        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition); //Just a ray through the middle of your current view
        RaycastHit hit;
        Vector3 targetPoint = ray.GetPoint(30);
        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread; //Just add spread to last direction
        //Rotate bullet to shoot direction
        transform.forward = directionWithSpread.normalized;
        //Add forces to bullet
        rb.AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        // Explode
        

      
    
        
    }

    public void Explode()
    {   
        
         Instantiate(ExplodeEffect, transform.position, transform.rotation);
         Collider[] obj_collider = Physics.OverlapSphere(transform.position, radius);
         foreach (Collider nearby_obj in obj_collider)
         {
            Rigidbody obj_rb = nearby_obj.GetComponent<Rigidbody>();
            if (obj_rb != null)
            {
                obj_rb.AddExplosionForce(force, transform.position, radius);
            }
         }
        
         Destroy(gameObject);
    }
     
    
    
}


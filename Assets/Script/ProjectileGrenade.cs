
using UnityEngine;
using TMPro;

public class ProjectileGrenade : MonoBehaviour
{
    //bullet 
    public GameObject grenade;

    //bullet force
    public float shootForce, upwardForce;

    //Gun stats
    public float spread;

  
  

   

    //Recoil
    public Rigidbody playerRb;
   

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //bug fixing :D
    public bool allowInvoke = true;

    public GameObject player;
    private float zgun;
    Rigidbody rb;
    private void Awake()
    {
        //make sure magazine is full
       
        readyToShoot = true;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {   
        if (CameraControll.grenade_equipped)
        {
            MyInput();
        }
        

        //Set ammo display, if it exists :D
       
    }
    private void MyInput()
    {
        //Check if allowed to hold down button and take corresponding input
        
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading 
       
        //Reload automatically when trying to shoot without ammo
        
        //Shooting
        if (readyToShoot && shooting)
        {
            //Set bullets shot to 0
        
          

            Shoot();
            
            
        }
    }

    private void Shoot()
    {
        readyToShoot = false;
        transform.SetParent(null);

        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition); //Just a ray through the middle of your current view
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
        // GameObject currentBullet = Instantiate(grenade, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        transform.forward = directionWithSpread.normalized;
        

        //Add forces to bullet
        rb.AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        //Instantiate muzzle flash, if you have one
    
        
    }
    
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quay : MonoBehaviour
{   
    float z;
    bool start;
    Vector3 target;
    Quaternion rotation;
    float Rotationspeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {   
       
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;
        // if (Input.GetMouseButtonDown(0) )
        // {
        // //    if (Physics.Raycast(ray, out hit))
        // //    {    
        //     //    target = hit.point; 
        //     //    Vector3 relativepos = target - transform.position;
        //     //    rotation = Quaternion.LookRotation(relativepos, Vector3.up);
        //     //    transform.rotation = rotation;
               
             
        //     Debug.Log(Input.mousePosition);
        //     rotation = transform.rotation;  
        //  } else if (Input.GetMouseButton(0)){
        //      transform.rotation = rotation * Quaternion.Euler(Vector3.forward * Input.mousePosition.x );
        //  }
           
           
        }
    

   
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{   
    public float speed;
    public Transform orientation;

    public Rigidbody rb;
    public float jumpforce;
    bool Grounded;

    public LayerMask Ground;
    
    public Camera cam;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        MoveControll();
        
    }
    void MoveControll()
    {   
        Grounded = Physics.Raycast(transform.position, Vector3.down, 1f, Ground);
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -orientation.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += orientation.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -orientation.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += orientation.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y,0) ;
            rb.AddForce(Vector3.up * jumpforce * Time.deltaTime ,ForceMode.Impulse);
        }


    }
}

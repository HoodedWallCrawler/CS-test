using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{   
    LayerMask Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Explode" ,5);
    }
    void Explode()
    {   
        RaycastHit hit;
        
        if (Physics.SphereCast(transform.position, 30, transform.forward, out hit, Enemy))
        {
            Destroy(hit.collider.gameObject);
        }
    }
}

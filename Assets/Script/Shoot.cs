using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{   
    public GameObject Bulletprefab;
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(Bulletprefab , transform.position, transform.rotation);
        }
    }
}

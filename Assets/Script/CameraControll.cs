using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{   
    public float sensX;
    public float sensY;

    float mouseX;
    float mouseY;

    float xRotation;
    float yRotation;    

    public Transform orientation;
    public Transform character;
    public LayerMask Gun;
    public LayerMask Grenade;

    public static bool gun_equipped = false;
    public static bool grenade_equipped = false; 
    public static bool picked = false;

    public float distance = 3f;
    public Transform GunContainer;

    public Camera cam;
    public List<GameObject> list;
    
    GameObject bomb;

    float scroll;
    int x = 1;
   

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
       cam = GetComponent<Camera>();
       
    }

    // Update is called once per frame
    void Update()
    {   
        
        
       
        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f , 70f);

        // if (Input.GetMouseButton(0))
        // {
        mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * sensX * Time.deltaTime;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0 , yRotation, 0);
        character.rotation = Quaternion.Euler(0, yRotation, 0);
        // }
        if (Input.GetKey(KeyCode.E)){
            Collect(Gun,1);
            Collect(Grenade,2);
            picked = true;
           
        }
        // scroll = Input.mouseScrollDelta.y;
        // if (scroll >0)
        // {
        //     if (x==1)
        //     {
        //         x=0;
        //     }
        //     else{
        //         x =1;
        //     }
        // } 
        // if (x == 1)
        // {
        //     list[1].SetActive(true);
        //     list[0].SetActive(false);
        // }
        // else {
        //     list[1].SetActive(false);
        //     list[0].SetActive(true);
        // }
        // bomb = GameObject.Find("SM_Prop_Bomb_01");
        // if (bomb == null)
        // {   
        //     list[1].SetActive(true);
        // }



    }

    void Collect(LayerMask obj , int i )
    {   
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray , out hit , distance, obj))
        {   
            hit.collider.gameObject.transform.SetParent(GunContainer);
            hit.collider.gameObject.transform.localPosition = Vector3.zero;
            hit.collider.gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            hit.collider.gameObject.transform.localScale = Vector3.one;
            hit.rigidbody.isKinematic = true;
            hit.collider.isTrigger = true;
            if (obj == Gun)
            {
                gun_equipped = true;
            }
            if (obj == Grenade)
            {
                grenade_equipped = true;
            }
        }
    }    
}

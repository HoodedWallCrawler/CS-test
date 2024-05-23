using UnityEngine;

public class SwitchingWeapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int selected_weapon = 0;
    float scroll;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int previous_weapon = selected_weapon;
        if (CameraControll.picked == true)
        {
            SelectWeapon();
            CameraControll.picked = false;
        }
        scroll = Input.mouseScrollDelta.y;
        if(scroll > 0)
        {
            if (selected_weapon >= transform.childCount -1)
            {
                selected_weapon = 0;
            }
            else{
                selected_weapon++;
            } 
        }
        if(scroll < 0)
        {
            if (selected_weapon <= 0f)
            {
                selected_weapon = transform.childCount -1;
            }
            else{
                selected_weapon--;
            } 
        }
        if (previous_weapon != selected_weapon)
        {
            SelectWeapon();
        }
        if(transform.childCount == 1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
    }

    void SelectWeapon()
    {   
        int i =0;
        foreach(Transform weapon in transform)
        {
            if (i == selected_weapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else {
                weapon.gameObject.SetActive(false);
            }
            i++;

        }
        
    }
}   


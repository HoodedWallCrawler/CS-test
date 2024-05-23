using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{   
    public TMP_Text HealthUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthUI.text = ((int)Move.health).ToString() + "/" + "100";
    }
}

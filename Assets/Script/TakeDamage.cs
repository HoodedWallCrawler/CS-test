using UnityEngine;

public class TakeDamage : MonoBehaviour
{   
    public float health = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision otherpart)
    {
        if (otherpart.gameObject.tag == "Bullet")
        {
            health -= 10;
        }
    }
}

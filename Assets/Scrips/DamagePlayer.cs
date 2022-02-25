using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        
    }


  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

     
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GunDamage : MonoBehaviour
{
   

    int headShot = 15;
    int DamageAmount = 5;
    int health = 15;
    public GameObject bullet;

    public GameObject zombie;

    private Animator animator;

    
    

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Bullet") && gameObject.CompareTag("Head"))
        {
            
            health = health - headShot;
            if (health <= 0)
            {
                animator.SetBool("Death", true);
                Destroy(zombie,2);
                
            }
        }
        else if(other.CompareTag("Bullet")&& gameObject.CompareTag("Body"))
        {
            
            health = health - DamageAmount;
            if (health <= 0)
            {
                animator.SetBool("Death", true);
                Destroy(zombie,2);
                
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);

    }
}

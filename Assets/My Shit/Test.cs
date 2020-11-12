using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public new Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        

            renderer.material.color = Color.red;
            Wait();
        
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bullet"))
            Wait();
            renderer.material.color = Color.white;
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);

    }
}

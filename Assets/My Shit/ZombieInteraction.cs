using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class ZombieInteraction : MonoBehaviour
{
    public FirstPersonController fpsc;
    public SphereCollider sphereCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            other.GetComponent<NpcController>().OnAware();
        }
    }
}

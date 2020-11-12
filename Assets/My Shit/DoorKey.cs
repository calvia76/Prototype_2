using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public bool Trigger;

    private void OnTriggerEnter(Collider other)
    {
        Trigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Trigger = false;
    }

    private void Update()
    {
        if (Trigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (this.gameObject.CompareTag("Door-Key"))
                {
                    DoorScipt.DoorKey = true;
                    Destroy(this.gameObject);
                }
                if (this.gameObject.CompareTag("Master-Key"))
                {
                    DoorScipt.MasterKey = true;
                    Destroy(this.gameObject);  
                }
            }
        }
    }
    private void OnGUI()
    {
        if (Trigger)
        {
            GUI.Box(new Rect(0, 60, 200, 25), "Press E to pick up key");
        }
    }

}

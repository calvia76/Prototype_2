using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveInfo : MonoBehaviour
{
    private bool Trigger;
    private void OnTriggerEnter(Collider other)
    {
        Trigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Trigger = false;
    }
    private void OnGUI()
    {
        if (Trigger)
        {
            GUI.Box(new Rect(450, 200, 300, 30), "Objective: Find rendezvous point and escape!");
        }
    }
}

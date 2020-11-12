using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class DoorScipt : MonoBehaviour
{
    public static bool DoorKey, MasterKey;
    public bool RoomDoorClose, MasterDoorClose;
        public bool doorOpen; //once doors are opened, these are the placeholders
        public bool MasterDoorOpen, RoomDoorOpen, DoorKeyTrigger, MasterKeyTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("DoorKey"))
            DoorKeyTrigger = true;
        if (gameObject.CompareTag("MasterKey"))
            MasterKeyTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        DoorKeyTrigger = false;
        MasterKeyTrigger = false;
    }
    void Update()
    {
        if (DoorKeyTrigger)
        {
            if (RoomDoorClose)
            {
                if (DoorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        RoomDoorOpen = true;
                        RoomDoorClose = false;

                    }
                }
                
            }
            else
            {
                if (DoorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        RoomDoorOpen = false;
                        RoomDoorClose = true;
                    }
                }
            }
        }
        if (MasterKeyTrigger)
        {
            if (MasterDoorClose)
            {
                if (MasterKey)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        MasterDoorOpen = true;
                        MasterDoorClose = false;
                    }
                }
                
            }
            else
            {
                if (MasterKey)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        MasterDoorOpen = false;
                        MasterDoorClose = true;
                    }
                }
            }
        }
        if (RoomDoorOpen && DoorKeyTrigger)
        {
            var rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 90f, 0.0f), Time.deltaTime * 200);
            transform.rotation = rotation;
        }
        else if (RoomDoorClose && DoorKeyTrigger)
        {
            var rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = rotation;
        }
        else if(MasterDoorOpen && MasterKeyTrigger)
        {
            var rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 90f, 0.0f), Time.deltaTime * 200);
            transform.rotation = rotation;
        }
        else if(MasterDoorClose && MasterKeyTrigger)
        {
            var rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = rotation;
        }

    }
    void OnGUI()
    {
        if (DoorKeyTrigger || MasterKeyTrigger)
        {
            if (RoomDoorOpen)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press E to close");
            }
            else if (MasterDoorOpen)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press E to close");
            }
            else
            {
               
                if(DoorKey && DoorKeyTrigger)
                    GUI.Box(new Rect(0, 0, 200, 25), "Press E to open");
                if (MasterKey && MasterKeyTrigger)
                    GUI.Box(new Rect(0, 0, 200, 25), "Press E to open");
                
                else
                {

                    if (DoorKeyTrigger && !DoorKey)
                    
                        GUI.Box(new Rect(0, 0, 220, 25), "Door is locked, 'Door Key' required");
                    
                    if (MasterKeyTrigger && !MasterKey)
                    
                        GUI.Box(new Rect(0, 0, 220, 25), "Door is locked 'Master Key' required");
                    
                }
            }
        }
    }
}

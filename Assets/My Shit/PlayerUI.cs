using System.Collections;
using System.Collections.Generic;
using System.Net;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerUI : MonoBehaviour
{
    
    public int maxHP;
    public Text uiHP;
    private int currHP;
    private int zombieDmg = 5;
    private bool isAttacking;

    public Text MedKits;
    private int currMedKits;
    public static bool MedPickUp;
    private bool hpFull;
    private bool hpHigh;
    private bool noMedKits;
    private float msgStartTime = 2.0f;

 
    public DeathMenu deathMenu;


    public float damageTickTime = 1.0f;
    private float damageTickCoolDown;
    private void Start()
    {
        
        currHP = maxHP;
        UpdateGUI();
    }
    private void Update()
    {
        if (isAttacking)
        {
            if (damageTickCoolDown <= 0.0f) 
            {
                currHP = currHP - zombieDmg;
                UpdateGUI();
                damageTickCoolDown = damageTickTime;

                if (currHP == 0)
                {
                    SceneManager.LoadScene("Death");
                }
            }
            else
            {
                damageTickCoolDown -= Time.deltaTime;
            }
            
        }
        if (MedPickUp)
        {
            MedPickUp = false;
            currMedKits += 1;
            UpdateGUI();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(currMedKits == 0)
            {
                noMedKits = true;
            }
            if ((currHP == maxHP) && currMedKits > 0)
            {
                hpFull = true;   
            }
            if((currHP == maxHP - 10) && currMedKits > 0)
            {
                hpHigh = true;   
            }
            if((currHP < maxHP-10) && currMedKits > 0)
            {
                currMedKits = currMedKits - 1;
                currHP = currHP + 15;
                UpdateGUI();
            }
        }
    }
    void UpdateGUI()
    {
        uiHP.text = currHP.ToString();
        MedKits.text = currMedKits.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        isAttacking = true;
        damageTickCoolDown = 0.0f;
    }
    private void OnTriggerExit(Collider other)
    {
        isAttacking = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        noMedKits = false;
    }
    private void OnGUI()
    {
        if (hpFull)
        {
            GUI.Box(new Rect(500, 200, 200, 25), "Health is full!");
            msgStartTime -= Time.deltaTime;
            if(msgStartTime < 0)
            {
                hpFull = false;
                msgStartTime = 2.0f;
            }
        }
        if (hpHigh)
        {
            GUI.Box(new Rect(500, 200, 200, 25), "Health too high!");
            hpHigh = false;
            if (msgStartTime < 0)
            {
                hpHigh = false;
                msgStartTime = 2.0f;
            }
        }
        if (noMedKits)
        {
            GUI.Box(new Rect(500, 200, 200, 25), "You have no MedKits!");
            msgStartTime -= Time.deltaTime;
            if (msgStartTime < 0)
            {
                noMedKits = false;
                msgStartTime = 2.0f;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Win();
        }
    }
    void Win()
    {
        SceneManager.LoadScene("Win");
    }
    public void Continue()
    {
        SceneManager.LoadScene("Menu");
    }
}

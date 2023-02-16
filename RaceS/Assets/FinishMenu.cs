using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    public GameManagerScript scr;
    float TimeStart = 0;
    bool timerRunning = true;
    public void Update()
    {
        if (timerRunning == true)
        {
            TimeStart += Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            timerRunning = false;
            scr.time= TimeStart;
            SceneManager.LoadScene(1);
        }
        else if (col.tag == "AI")
        {
            scr.count = 1;
        }
    }
}

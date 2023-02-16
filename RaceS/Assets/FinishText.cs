using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FinishText : MonoBehaviour
{
    public UnityEngine.UI.Text Label;
    public UnityEngine.UI.Text TimeText;
    private void Update()
    {
        GameObject manager = GameObject.Find("GameManager");
        TimeText.text = "���� �����: " + manager.GetComponent<GameManagerScript>().time.ToString("F2");
        if (manager.GetComponent<GameManagerScript>().count == 0)
        {
            if (Label != null)
                Label.text = "1-� �����";
        }
        else
        {
            if (Label != null)
                Label.text = "2-� �����";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    public GameObject Point;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Point.GetComponent<MeshRenderer>().enabled = false;
            UnityEngine.Debug.Log("Trigger");
        }
    }
   
}

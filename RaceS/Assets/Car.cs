using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField] private WheelCollider[] frontCols;
    [SerializeField] private Transform[] dataFront;
    [SerializeField] private WheelCollider[] backCol;
    [SerializeField] private Transform[] dataBack;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float maxSpeed = 400f;
    private float sideSpeed = 30f;


    void Update()
    {
        
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");
        rb = GetComponent<Rigidbody>();
       
        frontCols[0].motorTorque = vAxis * maxSpeed;
        frontCols[1].motorTorque = vAxis * maxSpeed;
        //UnityEngine.Debug.Log(vAxis);
        if (Input.GetKeyDown(KeyCode.Space))
        {       
            rb.drag = 1f;                      
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.drag = 0f;  
        }
   
        frontCols[0].steerAngle = hAxis * sideSpeed;
        frontCols[1].steerAngle = hAxis * sideSpeed;
      
        dataFront[0].Rotate( -frontCols[0].rpm * Time.deltaTime, 0, 0);
        dataFront[1].Rotate( -frontCols[1].rpm * Time.deltaTime, 0, 0);
        dataBack[0].Rotate( -backCol[0].rpm * Time.deltaTime, 0, 0);
        dataBack[1].Rotate( -backCol[1].rpm * Time.deltaTime, 0, 0);
        dataFront[0].localEulerAngles = new Vector3(dataFront[0].localEulerAngles.x, hAxis * sideSpeed, dataFront[0].localEulerAngles.z);
        dataFront[1].localEulerAngles = new Vector3(dataFront[1].localEulerAngles.x, hAxis * sideSpeed, dataFront[1].localEulerAngles.z);
       
    }
}

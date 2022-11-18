using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Npc_Car : MonoBehaviour
{

    [SerializeField] private WheelCollider[] frontCols;
    [SerializeField] private Transform[] dataFront;
    [SerializeField] private WheelCollider[] backCol;
    [SerializeField] private Transform[] dataBack;
    
    float TimeStart = 1f;
    [SerializeField] private Transform[] Points;
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField] private float maxSpeed = 1f;
    float sideSpeed = 30f;
    [SerializeField] private float distanceToChangePoint;
    int currentPoint = -1;
    float StartPosX;
    float EndPosX;
    float StartPosY;
    float EndPosY;
    float vAxis = 0;
    float hAxis = 0;


    void Start() 
    {
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = Points[0].position;
        StartPosX = transform.position.x;
        StartPosY = transform.position.y;

    }

    void Update()
    {

        TimeStart -= Time.deltaTime;

        EndPosX = transform.position.x;
        EndPosY = transform.position.y;

        vAxis = (EndPosX - StartPosX) * 3760f;
        if (vAxis > 1) vAxis = 1;
        if (vAxis < -1) vAxis = -1;
        //UnityEngine.Debug.Log(vAxis);
        StartPosX = EndPosX;

        if (EndPosY != StartPosY)
        {
            hAxis = (EndPosY - StartPosY) * 3760f;
            //if (hAxis > 1) hAxis = 1;
            //if (hAxis < -1) hAxis = -1;
            UnityEngine.Debug.Log(hAxis);
            StartPosY = EndPosY;
        }

        //float vAxis = Input.GetAxis("Vertical");
        //float hAxis = Input.GetAxis("Horizontal");

        if (TimeStart <= 0 && currentPoint != Points.Length)
        {
            agent.enabled = true;
        }
        if (agent.remainingDistance < distanceToChangePoint)
        {
            currentPoint++;
            if (currentPoint == Points.Length)
            {
                agent.enabled = false;
            }
            agent.destination = Points[currentPoint].position;
        }

        frontCols[0].motorTorque = vAxis * maxSpeed;
        frontCols[1].motorTorque = vAxis * maxSpeed;

        frontCols[0].steerAngle = hAxis * sideSpeed;
        frontCols[1].steerAngle = hAxis * sideSpeed;

        dataFront[0].Rotate(-frontCols[0].rpm * Time.deltaTime*5, 0, 0);
        dataFront[1].Rotate(-frontCols[1].rpm * Time.deltaTime*5, 0, 0);
        dataBack[0].Rotate(-backCol[0].rpm * Time.deltaTime, 0, 0);
        dataBack[1].Rotate(-backCol[1].rpm * Time.deltaTime, 0, 0);
        dataFront[0].localEulerAngles = new Vector3(dataFront[0].localEulerAngles.x, hAxis * sideSpeed, dataFront[0].localEulerAngles.z);
        dataFront[1].localEulerAngles = new Vector3(dataFront[1].localEulerAngles.x, hAxis * sideSpeed, dataFront[1].localEulerAngles.z);
        

    }
}

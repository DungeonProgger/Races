using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Npc_Car : MonoBehaviour
{

    public WheelCollider[] frontCols;
    public Transform[] dataFront;
    public WheelCollider[] backCol;
    public Transform[] dataBack;   
    public Transform target;
    private float TimeStart = 1f;
    public Transform[] Points;
    UnityEngine.AI.NavMeshAgent agent;

    public float maxSpeed = 400f;
    private float sideSpeed = 30f;
    public float distanceToChangePoint;
    int currentPoint = -1;

    void Start() {
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = Points[0].position;

    }



    void Update()
    {

        TimeStart -= Time.deltaTime;

        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");

        

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




        //frontCols[0].motorTorque = vAxis * maxSpeed;
        //frontCols[1].motorTorque = vAxis * maxSpeed;

        //frontCols[0].steerAngle = hAxis * sideSpeed;
        //frontCols[1].steerAngle = hAxis * sideSpeed;

        dataFront[0].Rotate(-frontCols[0].rpm * Time.deltaTime, 0, 0);
        dataFront[1].Rotate(-frontCols[1].rpm * Time.deltaTime, 0, 0);
        dataBack[0].Rotate(-backCol[0].rpm * Time.deltaTime, 0, 0);
        dataBack[1].Rotate(-backCol[1].rpm * Time.deltaTime, 0, 0);
        dataFront[0].localEulerAngles = new Vector3(dataFront[0].localEulerAngles.x, hAxis * sideSpeed, dataFront[0].localEulerAngles.z);
        dataFront[1].localEulerAngles = new Vector3(dataFront[1].localEulerAngles.x, hAxis * sideSpeed, dataFront[1].localEulerAngles.z);
        

    }
}

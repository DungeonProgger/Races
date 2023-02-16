using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject Car;
    public float distance = 100;
    void LateUpdate()
    {
        transform.position = Car.transform.position + Vector3.up * distance;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficZone : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            print("CAR EXIT TO TRAFFIC ZONE");
            var transformCar = other.transform;
            var position = transformCar.position;
            position = new Vector3(-position.x, position.y, -position.z);
            transformCar.position = position;
        }
    }
}

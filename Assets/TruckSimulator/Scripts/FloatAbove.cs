using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for making the CrasAlert prefab instantiated float above as seen when the playerTruck crashes into a gameobject with the "Obstacle" tag.
/// Location:  in the CrashAlert prefab at "Assets/TruckSimulator/Prefabs/crashEffect"
/// </summary>
namespace TruckSimulatorTemplate
{
    public class FloatAbove : MonoBehaviour
    {
        public float speed;

        void Update()
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }

    }
}



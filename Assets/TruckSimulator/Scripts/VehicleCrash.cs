using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// This script is responsible for registering and calling the crasheffect when the plyerTruck crashes into an Obstacle.
/// Location: located on the "Front__.sc" gameobject on each playerTruck prefab.
/// </summary>

namespace TruckSimulatorTemplate
{
    public class VehicleCrash : MonoBehaviour
    {

        public AudioSource crashSound;
        public int crashcount;
        public GameObject crashEffect;
        public GameObject canvasCrashAlert;

        void Start()
        {

        }

        void OnCollisionEnter(Collision collision)
        {


            if (collision.gameObject.CompareTag("Obstacle"))
            {

                crashcount++;
                collision.gameObject.tag = "Untagged";
                crashSound.Play();

                crashEffect = Instantiate(crashEffect, collision.transform.position, Quaternion.identity);

                Instantiate(canvasCrashAlert, transform.position, Quaternion.identity);



            }


        }
    }
}


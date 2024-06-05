using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script is responsible for counting and storing the number of times playerTruck enters its red bubble (a sphere trigger gameObject).
/// It helps in calculating the distance the playerTruck has covered in the GameOverCaller script and FinishLineTrigger script.
/// Location:  on each environment scenes (Env0, Env1, etc) "Env0Track0(Clone)/DistancePoints__.sc" when game is being played.
/// </summary>

namespace TruckSimulatorTemplate
{
    public class DistanceCalulation : MonoBehaviour
    {
        int previousDistanceRecorded;
        void Start()
        {
            PlayerPrefs.SetInt("distanceCovered", 0);
        }
 
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerTruck"))
            {

                previousDistanceRecorded = PlayerPrefs.GetInt("distanceCovered");
                PlayerPrefs.SetInt("distanceCovered", (previousDistanceRecorded  + 1));
               

            }
        }
    }
}


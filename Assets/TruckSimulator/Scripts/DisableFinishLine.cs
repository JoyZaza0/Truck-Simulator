using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// This script is responsible for disabling the trigger finish line to prevent its finishpanel being called in case the playerTruck just enters it at the moment gameOver too is called.
/// Location:  
/// </summary>


namespace TruckSimulatorTemplate
{
   
    public class DisableFinishLine : MonoBehaviour
    {
        GameObject track, finishline;
        void Start()
        {
            track = GameObject.Find("INSTANTIATORS__.sc").GetComponent<TruckInstantiator>().track;
            finishline = track.transform.Find("TriggerFinshline__.sc").gameObject;
            finishline.SetActive(false);
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script is responsible for disabling the Introduction panel for the second introduction (the privacy policy) to appear.
/// Location: HomeScene  "CanvasPanels__.sc>>/FRESHGAMEPanel__.sc>>/Intro1__.sc" 
/// </summary>

namespace TruckSimulatorTemplate
{
    public class DisableIntro : MonoBehaviour
    {
        public float timeToDisable;
        public GameObject intro2;
        void Start()
        {
            Invoke("Disable", timeToDisable);
        }


        void Disable()
        {
            this.transform.gameObject.SetActive(false);
            intro2.SetActive(true);
        }
    }

}

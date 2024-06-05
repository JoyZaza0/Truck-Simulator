using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for disabling the GO! alert when the game starts.
/// Location:  on each environment scenes (Env0, Env1, etc) such as "TruckPlayer0(Clone)/CanvasCarControl__.sc/ControlButtons__.sc" when game is being played.
/// </summary>


namespace TruckSimulatorTemplate
{
    public class GoDisable : MonoBehaviour
    {
        public GameObject go;
        void Start()
        {
            Invoke("disableGo", 5f);
        }

        public void disableGo()
        {
            go.SetActive(false);
        }
    }
}


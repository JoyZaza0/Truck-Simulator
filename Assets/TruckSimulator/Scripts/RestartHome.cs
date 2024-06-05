using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script retarts the game or sends you to the homescene.
/// Location: on each Environment scene (such as Env0) "Env0Track0(Clone)/CanvasDisplayPanel/FinishDisplay__.sc" during play mode.
/// </summary>

namespace TruckSimulatorTemplate
{
    public class RestartHome : MonoBehaviour
    {

        public void RestartPressed()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);            
        }


        public void HomePressed()
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetString("SwitchToHomePanel", "yes");
        }
    }
}


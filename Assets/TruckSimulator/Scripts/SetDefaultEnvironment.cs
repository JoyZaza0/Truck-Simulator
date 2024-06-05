using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;

/// <summary>
/// This script works with the SetDefaultLevel.sc. It makes the HomePanel appear when you exit your environment scene (such as Env0) by pressing the HomePanel.
/// But then istantaneously the HomePanel appear, SetDefault.cs takes over and do what it does.
/// Location: HomeScene "CanvasPanels__.sc>>/HOMEPanel__.sc".
/// </summary>

namespace TruckSimulatorTemplate
{
    public class SetDefaultEnvironment : MonoBehaviour
    {
        public UiGameObjects uiGameObjects;
        void OnEnable()
        {
            if (PlayerPrefs.GetString("SwitchToHomePanel") == "yes")
            {
               // uiGameObjects.envPlayLevelsPanels[(GameData.GetSelectedEnv())].SetActive(true);
               // uiGameObjects.levelDescriptionPanel.SetActive(true);
                uiGameObjects.CoinsAtTheTopPanel.SetActive(false);
            }
        }


    }
}



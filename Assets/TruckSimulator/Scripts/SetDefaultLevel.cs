using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;

/// <summary>
/// This script works with the SetDefaultEnvironment.sc. It makes this gameObject (such as EnvironmentPanel0__.sc) it sits on, appear after you have switched over from
/// from any environment scene (such as Env0 scene) during play mode by pressing the home button icon. 
/// But then istantaneously the HomePanel appear, SetDefault.cs takes over and do what it does.
/// Location: HomeScene "CanvasPanels__.sc>>/HOMEPanel__.sc".
/// </summary>

namespace TruckSimulatorTemplate
{
    public class SetDefaultLevel : MonoBehaviour
    {
        public UiGameObjects uiGameObjects;
        ConfigureLevels configureLevels;
        public GameObject playButton;
        void Start()
        {

        }

        void OnEnable()
        {

            configureLevels = this.gameObject.GetComponent<ConfigureLevels>();
            Set();
        }
        void Set()
        {
            uiGameObjects.timeOfdayImage.sprite = configureLevels.configureLevelsElements[GameData.GetJustPlayedLevel(GameData.GetSelectedEnv())].timeImage;
            uiGameObjects.levDescriptionImage.sprite = configureLevels.configureLevelsElements[GameData.GetJustPlayedLevel(GameData.GetSelectedEnv())].levImage;
            uiGameObjects.levTruckImageToUse.sprite = configureLevels.configureLevelsElements[GameData.GetJustPlayedLevel(GameData.GetSelectedEnv())].TruckImage;
            uiGameObjects.levDescriptionText.text = configureLevels.configureLevelsElements[GameData.GetJustPlayedLevel(GameData.GetSelectedEnv())].levDescription;

            uiGameObjects.levMaxCountDownText.text = configureLevels.configureLevelsElements[GameData.GetSelectedLevel()].timeToBeat.ToString() + "  seconds";
            uiGameObjects.levMaxCrashCountText.text = configureLevels.configureLevelsElements[GameData.GetSelectedLevel()].MaxCrashes.ToString();

        }


    }
}


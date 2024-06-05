using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TruckSimulatorTemplate;



/// <summary>
/// This script is responsible for making the next adjacent level clickable when a current level has been played. That is, removing the Padlock Image and making button interactable.
/// Location: HomeScene "CanvasPanels__.sc>>/EnvironmentPanel0__.sc || EnvironmentPanel1__.sc || EnvironmentPanel2__.sc || EnvironmentPanel3__.sc || EnvironmentPanel4__.sc"
/// </summary>

namespace TruckSimulatorTemplate
{
    public class MakeNextLevelPlayable : MonoBehaviour
    {

        public Button[] buttons;
        public GameObject[] lockImages;
        void OnEnable()
        {
            Debug.Log(GameData.GetSelectedEnv());
            for (int i = 0; i < buttons.Length; i++)
            {

                if (GameData.GetLevelScore(GameData.GetSelectedEnv(), i) >= 10)
                {
                     
                        buttons[i + 1].interactable = true;
                        lockImages[i + 1].SetActive(false);
                    

                }

            }
        }



    }

}

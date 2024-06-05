using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TruckSimulatorTemplate;


/// <summary>
///This script is referenced from the EditorResetter.cs script in the Editor folder and resets game values.
/// </summary>
namespace TruckSimulatorTemplate
{
    public class Resetter : MonoBehaviour
    {

        public TruckProperties trucksProperties;
        public UiGameObjects uiGameObjects;


        void Start()
        {
            
            if (!PlayerPrefs.HasKey("IsEntireGameReset"))
            {

                GameData.SetCoinsAmount(0);
                GameData.SetSelectedControltype("arrows");
                GameData.SetMusicVolume(0.5f);
                GameData.SetSfxVolume(0.5f);
                GameData.SetQuality(1);

                uiGameObjects.FreshgamePanel.SetActive(true);
                uiGameObjects.EntryPanel.SetActive(false);

                GameData.SetFreshGameStatus("no");

            }
            else
            {
                if (PlayerPrefs.GetString("SwitchToHomePanel") == "yes")
                {
                    uiGameObjects.FreshgamePanel.SetActive(false);
                    uiGameObjects.EntryPanel.SetActive(false);
                    uiGameObjects.HomePanel.SetActive(true);
                    uiGameObjects.CoinsAtTheTopPanel.SetActive(true);
                }
                else
                {
                  
                    uiGameObjects.FreshgamePanel.SetActive(false);
                    uiGameObjects.EntryPanel.SetActive(true);
                }

            }


        }

        void OnApplicationQuit()
        {
               PlayerPrefs.SetString("SwitchToHomePanel", "no");
        }


    }

}

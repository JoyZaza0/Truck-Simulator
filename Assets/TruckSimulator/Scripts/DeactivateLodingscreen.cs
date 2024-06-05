using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for disabling the loading screen at the start of the game.
/// Location: on each playerTruck prefab "CanvasCarControl__.sc"
/// </summary>

namespace TruckSimulatorTemplate
{
    public class DeactivateLodingscreen : MonoBehaviour
    {
        public GameObject loadingScreen;
        public GameObject controlsButton;
        [HideInInspector]
        public SettingsMenu settingsMenu;
        void Start()
        {

        }
        public void DeactivateLoadingScreen()
        {
            loadingScreen.SetActive(false);
            controlsButton.SetActive(true);
            settingsMenu = GameObject.Find("Canvas__.sc>>/GameplayScreenItems__.sc>>/pauseBtn__.sc").GetComponent<SettingsMenu>();
            settingsMenu.controlsButtons = this.transform.gameObject;
        }


        void Update()
        {

        }
    }
}


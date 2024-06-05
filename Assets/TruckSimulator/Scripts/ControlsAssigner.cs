using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for enabling the selected control type when the game scene opens in play mode or after you exit the pause menu.
/// Location: on each playerTruck prefab "CanvasCarControl__.sc".
/// </summary>
namespace TruckSimulatorTemplate
{
    public class ControlsAssigner : MonoBehaviour
    {
        public GameObject arrowsButtons, tiltButtons, SteerwheelButtons;
        void OnEnable()
        {
           
            string assignedControl = GameData.GetSelectedControltype();

            if (assignedControl == "arrows")
            {
                arrowsButtons.SetActive(true);
                tiltButtons.SetActive(false);
                SteerwheelButtons.SetActive(false);
            }
            else if (assignedControl == "tilt")
            {
                tiltButtons.SetActive(true);
                arrowsButtons.SetActive(false);
                SteerwheelButtons.SetActive(false);
            }
            else if (assignedControl == "steerwheel")
            {
                SteerwheelButtons.SetActive(true);
                tiltButtons.SetActive(false);
                arrowsButtons.SetActive(false);
            }


        }



    }
}


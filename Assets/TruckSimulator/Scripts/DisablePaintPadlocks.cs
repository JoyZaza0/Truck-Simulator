using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;


/// <summary>
/// This script is responsible for disabling the paint padlocks Images when the Customization panel is opened.
/// Location:  HomeScene "CUSTOMISETRUCK__.sc"
/// </summary>

namespace TruckSimulatorTemplate
{
    public class DisablePaintPadlocks : MonoBehaviour
    {
        public GameObject[] paintPadlocks;
        void Start()
        {
            GameData.SetPaintPadlockStatus(0, "yes");

            for (int i = 0; i < paintPadlocks.Length; i++)
            {
                if (GameData.GetPaintLockImageStatus(i) == "yes")
                {
                    paintPadlocks[i].SetActive(false);

                }
                else
                {
                    paintPadlocks[i].SetActive(true);
                }
            }
        }


    }
}


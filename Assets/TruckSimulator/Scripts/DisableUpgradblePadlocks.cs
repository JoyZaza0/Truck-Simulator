using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;

/// <summary>
/// This script is responsible for disabling the upgradables padlocks Images when the Customization panel is opened.
/// Location:  HomeScene "CUSTOMISETRUCK__.sc"
/// </summary>

namespace TruckSimulatorTemplate
{
    public class DisableUpgradblePadlocks : MonoBehaviour
    {
        TruckProperties truckProperties;
        public GameObject[] sunshadePadlocks, bullbarPadlocks, topbarPadlocks, lowbarPadlocks, otherPadlocks;

        void Start()
        {
            truckProperties = GameObject.Find("PlayerTrucksProperties__.sc").GetComponent<TruckProperties>();

            GameData.SetSunshadePadlockStatus(0, "yes");
            GameData.SetBullbarPadlockStatus(0, "yes");
            GameData.SetTopbarPadlockStatus(0, "yes");
            GameData.SetLowbarPadlockStatus(0, "yes");
            GameData.SetOtherPadlockStatus(0, "yes");

        }
        public void DisablePadlocks()
        {
            for (int i = 0; i < 5; i++)
            {
                if (GameData.GetSunshadePadlockStatus(i) == "yes")
                {
                    sunshadePadlocks[i].SetActive(false);

                }
                else
                {
                    sunshadePadlocks[i].SetActive(true);
                }
                //=-----------------------------------------------------------------------
                if (GameData.GetBullbarPadlockStatus(i) == "yes")
                {
                    bullbarPadlocks[i].SetActive(false);

                }
                else
                {
                    bullbarPadlocks[i].SetActive(true);
                }
                //=-----------------------------------------------------------------------
                if (GameData.GetTopbarPadlockStatus(i) == "yes")
                {
                    topbarPadlocks[i].SetActive(false);

                }
                else
                {
                    topbarPadlocks[i].SetActive(true);
                }
                //=-----------------------------------------------------------------------
                if (GameData.GetLowbarPadlockStatus(i) == "yes")
                {
                    lowbarPadlocks[i].SetActive(false);

                }
                else
                {
                    lowbarPadlocks[i].SetActive(true);
                }
                //=-----------------------------------------------------------------------
                if (GameData.GetOtherPadlockStatus(i) == "yes")
                {
                    otherPadlocks[i].SetActive(false);

                }
                else
                {
                    otherPadlocks[i].SetActive(true);
                }
            }
 
        }

    }

}

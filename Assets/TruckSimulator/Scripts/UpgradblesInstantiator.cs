using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;
 
/// <summary>
/// This script activates (setActive) the right upgradables located in each playerTruck on the "Truck__sc" gameobject when the game starts playing in their environment scenes.
/// Location: HomeScene "ISTANTIATORS__.sc".
/// </summary>

namespace TruckSimulatorTemplate
{
    public class UpgradblesInstantiator : MonoBehaviour
    {
        [Header("-> Activate Upgradables on playerTruck by reading from the\n      Json saved TruckProperties")]
        [Space]
        [Space]
        public TruckProperties truckProperties;
        public TruckInstantiator truckInstantiator;
        [HideInInspector]
        public UpgradblesOnPlayerTruck upgradblesOnPlayerTruck;
        [HideInInspector]
        public GameObject selectedTruck;
        TruckController truckController;

        void Start()
        {
            
            Invoke("CallLater", 0.5f);
             
            //truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].sunshadeId;//
        }
        void CallLater()
        {
            selectedTruck = truckInstantiator.selectedTruck;

            upgradblesOnPlayerTruck = selectedTruck.transform.Find("Truck__.sc").GetComponent<UpgradblesOnPlayerTruck>();

            upgradblesOnPlayerTruck.sunshades[truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].sunshadeId].SetActive(true);

            upgradblesOnPlayerTruck.bullbars[truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].bullbarId].SetActive(true);

            upgradblesOnPlayerTruck.topbars[truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].topbarId].SetActive(true);

            GameObject activeTopbar = upgradblesOnPlayerTruck.topbars[truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].topbarId];

            GameObject spotLight = activeTopbar.transform.Find("SpotLight").gameObject;

            if (GameData.GetTimeOfDay() == 1 || GameData.GetTimeOfDay() == 2)
            {
                spotLight.SetActive(true);
            }
            else
            {
                spotLight.SetActive(false);
            }

            upgradblesOnPlayerTruck.lowbars[truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].lowbarId].SetActive(true);

            upgradblesOnPlayerTruck.other[truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].otherId].SetActive(true);

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;

/// <summary>
/// This script is responsible for what happens when you select upgradables int he garagePanel.
/// Location: HomeScene "CUSTOMIZETRUCK__.sc".
/// </summary>

namespace TruckSimulatorTemplate
{
    public class SelectGarageUpgradables : MonoBehaviour
    {

        public Upgradables upgradables;
        public InstantiateGarageTrucks instantiateGarageTrucks;
        TruckProperties truckProperties;
        BuyUpgradables buyUpgradables;
        DisableUpgradblePadlocks disableUpgradblePadlocks;
        [HideInInspector]
        public List<GameObject> sunshadesUpgradablesList = new List<GameObject>();
        [HideInInspector]
        public List<GameObject> bullbarsUpgradblesList = new List<GameObject>();
        [HideInInspector]
        public List<GameObject> topbarsUpgradablesList = new List<GameObject>();
        [HideInInspector]
        public List<GameObject> lowbarsUpgradablesList = new List<GameObject>();
        [HideInInspector]
        public List<GameObject> otherUpgradablesList = new List<GameObject>();

        [HideInInspector]
        public GameObject[] sunshades, bullbars, topbars, lowbars, others;


        void Start()
        {
            instantiateGarageTrucks = GetComponent<InstantiateGarageTrucks>();
            truckProperties = GameObject.Find("PlayerTrucksProperties__.sc").GetComponent<TruckProperties>();
            buyUpgradables = GetComponent<BuyUpgradables>();
            disableUpgradblePadlocks = GetComponent<DisableUpgradblePadlocks>();

        }

        public void AddToListsAndInstantiate()
        {
            for (int i = 0; i < 5; i++)
            {
                sunshadesUpgradablesList.Add(upgradables.upgradable[i].sunshade);
                sunshades[i] = Instantiate(sunshadesUpgradablesList[i], instantiateGarageTrucks.truckInGarage.transform.Find("sunshadePosition"));

                bullbarsUpgradblesList.Add(upgradables.upgradable[i].bullbar);
                bullbars[i] = Instantiate(bullbarsUpgradblesList[i], instantiateGarageTrucks.truckInGarage.transform.Find("bullbarsPosition"));

                topbarsUpgradablesList.Add(upgradables.upgradable[i].topbar);
                topbars[i] = Instantiate(topbarsUpgradablesList[i], instantiateGarageTrucks.truckInGarage.transform.Find("topbarsPosition"));

                lowbarsUpgradablesList.Add(upgradables.upgradable[i].lowbar);
                lowbars[i] = Instantiate(lowbarsUpgradablesList[i], instantiateGarageTrucks.truckInGarage.transform.Find("lowbarsPosition"));

                otherUpgradablesList.Add(upgradables.upgradable[i].other);
                others[i] = Instantiate(otherUpgradablesList[i], instantiateGarageTrucks.truckInGarage.transform.Find("otherPosition"));

            }
            //===========================================================================================================================================
            foreach (GameObject sunshade in sunshades)
            {
                sunshade.SetActive(false);
            }
            int selectedSunshade = truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].sunshadeId;
            sunshades[selectedSunshade].SetActive(true);


            foreach (GameObject bullbar in bullbars)
            {
                bullbar.SetActive(false);
            }
            int selectedBullbar = truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].bullbarId;
            bullbars[selectedBullbar].SetActive(true);

            foreach (GameObject topbar in topbars)
            {
                topbar.SetActive(false);
            }
            int selectedTopbar = truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].topbarId;
            topbars[selectedTopbar].SetActive(true);

            foreach (GameObject lowbar in lowbars)
            {
                lowbar.SetActive(false);
            }
            int selectedLowbar = truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].lowbarId;
            lowbars[selectedLowbar].SetActive(true);

            foreach (GameObject other in others)
            {
                other.SetActive(false);
            }
            int selectedOther = truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].otherId;
            others[selectedOther].SetActive(true);

        }
        //===========================================================================================================================================


        //===========================================================================================================================================


        public void SelectSunshadeUpgradableItem(int sunshadeIndex)
        {

            foreach (GameObject sunshade in sunshades)
            {
                sunshade.SetActive(false);
            }

            sunshades[sunshadeIndex].SetActive(true);
            buyUpgradables.sunshadeIndex = sunshadeIndex;
            buyUpgradables.buyInt = 0;

            if (!disableUpgradblePadlocks.sunshadePadlocks[sunshadeIndex].activeSelf)
            {
                GameData.SetSunshadePadlockStatus(sunshadeIndex, "yes");
                truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].sunshadeId = sunshadeIndex;
                truckProperties.UpdateProperties();
            }

        }
        public void SelectBullbarsUpgradableItem(int bullbarsIndex)
        {

            foreach (GameObject bullbar in bullbars)
            {
                bullbar.SetActive(false);
            }

            bullbars[bullbarsIndex].SetActive(true);
            buyUpgradables.bullbarIndex = bullbarsIndex;
            buyUpgradables.buyInt = 1;

            if (!disableUpgradblePadlocks.bullbarPadlocks[bullbarsIndex].activeSelf)
            {
                GameData.SetBullbarPadlockStatus(bullbarsIndex, "yes");
                truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].bullbarId = bullbarsIndex;
                truckProperties.UpdateProperties();
            }
        }
        public void SelectTopbarsUpgradableItem(int topbarsIndex)
        {

            foreach (GameObject topbar in topbars)
            {
                topbar.SetActive(false);
            }

            topbars[topbarsIndex].SetActive(true);
            buyUpgradables.topbarIndex = topbarsIndex;
            buyUpgradables.buyInt = 2;

            if (!disableUpgradblePadlocks.topbarPadlocks[topbarsIndex].activeSelf)
            {
                GameData.SetTopbarPadlockStatus(topbarsIndex, "yes");
                truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].topbarId = topbarsIndex;
                truckProperties.UpdateProperties();
            }
        }
        public void SelectLowbarsUpgradableItem(int lowbarsIndex)
        {

            foreach (GameObject lowbar in lowbars)
            {
                lowbar.SetActive(false);
            }

            lowbars[lowbarsIndex].SetActive(true);
            buyUpgradables.lowbarIndex = lowbarsIndex;
            buyUpgradables.buyInt = 3;

            if (!disableUpgradblePadlocks.lowbarPadlocks[lowbarsIndex].activeSelf)
            {
                GameData.SetLowbarPadlockStatus(lowbarsIndex, "yes");
                truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].lowbarId = lowbarsIndex;
                truckProperties.UpdateProperties();
            }
        }

        public void SelectOtherUpgradableItem(int otherIndex)
        {

            foreach (GameObject other in others)
            {
                other.SetActive(false);
            }

            others[otherIndex].SetActive(true);
            buyUpgradables.otherIndex = otherIndex;
            buyUpgradables.buyInt = 4;

            if (!disableUpgradblePadlocks.lowbarPadlocks[otherIndex].activeSelf)
            {
                GameData.SetOtherPadlockStatus(otherIndex, "yes");
                truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].otherId = otherIndex;
                truckProperties.UpdateProperties();
            }
        }

    }




}


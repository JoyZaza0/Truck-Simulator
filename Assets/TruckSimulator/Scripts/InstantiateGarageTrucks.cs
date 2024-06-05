using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TruckSimulatorTemplate;


/// <summary>
/// This script instantiates selected GarageTruck to be customised in the garage.
/// Location: HomeScene "CUSTOMIZETRUCK__.sc".
/// </summary>
namespace TruckSimulatorTemplate
{
    public class InstantiateGarageTrucks : MonoBehaviour
    {
        public UiGameObjects uiGameObjects;
        public GameObject uiCamera;
        public GarageTrucks garageTrucks;
        DisableUpgradblePadlocks disableUpgradblePadlocks;
        public Transform truckPositionInGarage;
        [HideInInspector]
        public GameObject truckInGarage;
        int trucknumber;

        void Start()
        {
            
            disableUpgradblePadlocks = GetComponent<DisableUpgradblePadlocks>();
        }


        public void CustomiseTruckPressed()   
        {

            truckInGarage = Instantiate(garageTrucks.garageTrucks[GameData.GetSelectedTruck()].garageTruck, truckPositionInGarage.position, truckPositionInGarage.rotation);
           
            uiGameObjects.truckInGarage = this.truckInGarage;

            PaintGarageTruck paintGarageTruck = this.gameObject.transform.GetComponent<PaintGarageTruck>();
            paintGarageTruck.FindAndAssignMeshrenderer();

            SelectGarageUpgradables selectGarageUpgradables = GetComponent<SelectGarageUpgradables>();
            selectGarageUpgradables.AddToListsAndInstantiate();

            disableUpgradblePadlocks.DisablePadlocks();

        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;


/// <summary>
/// This script is responsible for selecting what Load a playerTruck will carry or enable during its gameplay.
/// Location: in the "Assets/TruckSimulator/Prefabs/in each playerTruck/Truck__.sc" 
/// </summary>

namespace TruckSimulatorTemplate
{
    public class LoadsSelect : MonoBehaviour
    {
        public GameObject[] loads;
        void Start()
        {
            loads[GameData.GetTypeOfLoad(GameData.GetSelectedTruck())].SetActive(true);
        }


        void Update()
        {

        }
    }

}

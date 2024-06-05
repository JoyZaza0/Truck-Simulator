using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TruckSimulatorTemplate
{
    [CreateAssetMenu(fileName = "PlayerTrucks", menuName = "PlayerTrucks")]
    public class PlayerTrucks : ScriptableObject
    {
        public static PlayerTrucks instance;
        public static PlayerTrucks Instance
        {
            get
            {
                if (instance == null)
                    instance = Resources.Load("PlayerTrucks") as PlayerTrucks;
                return instance;
            }

        }
        [System.Serializable]
        public class Trucks
        {

            public GameObject playerTruck;


        }
        public Trucks[] playerTrucks;

    }
}


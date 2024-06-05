using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TruckSimulatorTemplate
{
    [CreateAssetMenu(fileName = "GarageTrucks", menuName = "GarageTrucks")]
    public class GarageTrucks : ScriptableObject
    {

        public static GarageTrucks instance;
        public static GarageTrucks Instance
        {
            get
            {
                if (instance == null)
                    instance = Resources.Load("GarageTrucks") as GarageTrucks;
                return instance;
            }

        }
        [System.Serializable]
        public class Trucks
        {

            public GameObject garageTruck;


        }
        public Trucks[] garageTrucks;

    }

}

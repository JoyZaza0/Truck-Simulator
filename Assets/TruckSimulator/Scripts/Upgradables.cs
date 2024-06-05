using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TruckSimulatorTemplate
{
    [CreateAssetMenu(fileName = "Upgradables", menuName = "Upgradables")]
    public class Upgradables : ScriptableObject
    {

        public static Upgradables instance;
        public static Upgradables Instance
        {
            get
            {
                if (instance == null)
                    instance = Resources.Load("Upgradables") as Upgradables;
                return instance;
            }

        }

        [System.Serializable]
        public class Upgradable
        {

            public GameObject sunshade;
            public int priceOfSunshade;


            public GameObject bullbar;
            public int priceOfbullbar;


            public GameObject topbar;
            public int priceOftopbar;

            public GameObject lowbar;
            public int priceOflowbar;

            public GameObject other;
            public int priceOfother;

        }
        public Upgradable[] upgradable;

    }


}


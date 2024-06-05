using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace TruckSimulatorTemplate
{
    [CreateAssetMenu(fileName = "EnvironmentTracks", menuName = "EnvironmentTracks")]
    public class EnvironmentTracks : ScriptableObject
    {

        public static EnvironmentTracks instance;
        public static EnvironmentTracks Instance
        {
            get
            {
                if (instance == null)
                    instance = Resources.Load("Env1Tracks") as EnvironmentTracks;
                return instance;
            }

        }

        [System.Serializable]
        public class EnvTracks
        {

            public GameObject track;



        }
        public EnvTracks[] envTracks;
    }
}

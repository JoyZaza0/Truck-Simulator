using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;

/// <summary>
/// This script instantiates selected playerTruck ( from GameData.GetSelectedTruc()) at the "spawnPoint" and the env track (from GameData.GetSelectedEnvTrack());
/// Location: on every environment scene (such as Env0 scene) "INSTANTIATORS__.sc".
/// </summary>

namespace TruckSimulatorTemplate
{
    public class TruckInstantiator : MonoBehaviour
    {
        [Header("->Spawn playerTruck and env Track")]
        [Space]
        [Space]
        public EnvironmentTracks EnvTracks;
        public PlayerTrucks playerTrucks;
        [HideInInspector]
        public GameObject selectedTruck;
        [HideInInspector]
        public GameObject track;
        void Start()
        {


            Time.timeScale = 1;
            track = Instantiate(EnvTracks.envTracks[GameData.GetSelectedEnvTrack()].track, Vector3.zero, Quaternion.identity);


            Transform spawnPoint = track.transform.Find("spawnPoint");


            selectedTruck = Instantiate(playerTrucks.playerTrucks[GameData.GetSelectedTruck()].playerTruck, spawnPoint.position, spawnPoint.rotation);
        }


    }
}


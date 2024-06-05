using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;

/// <summary>
/// This script is connected to the EditorSpawnDistancePoint.cs helps you easily instantiate Distance points in Editor mode.
/// Location:  on each environment scenes (Env0, Env1, etc) "Env0Track0(Clone)/DistancePoints__.sc" when game is being played.
/// </summary>

namespace TruckSimulatorTemplate
{

    public class DistancePointSpawner : MonoBehaviour
    {
        public GameObject prefab;
        public int NumberOfDistancePoints;
        [HideInInspector]
        public GameOverCaller gameOverCaller;


        void Start()
        {
            gameOverCaller = GameObject.Find("GAMEOVER__.sc").GetComponent<GameOverCaller>();
            gameOverCaller.totalDistancePoints = NumberOfDistancePoints;
        }



    }

}

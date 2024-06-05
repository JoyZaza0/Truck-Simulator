using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is responsible for disabling or destroying the "Crashed!" alert text prefab.
/// Location: CanvasCrashAlert prefab in the "Assets/TruckSimulator/Prefabs/Misc" folder.
/// </summary>
namespace TruckSimulatorTemplate
{
    public class DisableAlert : MonoBehaviour
    {
        void Start()
        {
            Invoke("Destroy", 1f);
        }


        void Destroy()
        {
            Destroy(gameObject);
        }
    }
}


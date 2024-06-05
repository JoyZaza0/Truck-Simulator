using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TruckSimulatorTemplate;


/// <summary>
/// This script paints the body of a playerTruck immediately in the playmode thier environment scenes.
/// Location: on each Environment scene (such as Env0) "INSTANTIATORS__.sc"
/// </summary>

namespace TruckSimulatorTemplate
{
    public class PaintInstantiator : MonoBehaviour
    {
        [Header("->Paint the playerTruck body")]
        [Space]
        [Space]
        public TruckProperties truckProperties;
        public TruckInstantiator truckInstantiator;
        [HideInInspector]

        public MeshRenderer meshRendererBody;
        public TruckPaints truckPaints;

        [HideInInspector]
        public MeshRenderer[] wheelmesherenders;


        void Start()
        {
            Invoke("CallLater", 0.5f);

            Debug.Log(truckPaints.paint[truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].paintId]);
        }
        public void CallLater()
        {

            meshRendererBody = truckInstantiator.selectedTruck.transform.Find("Truck__.sc/Front/SwappableMeshes/body").transform.GetComponent<MeshRenderer>();
            meshRendererBody.material = truckPaints.paint[truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].paintId].paintMaterial;

        }


    }
}


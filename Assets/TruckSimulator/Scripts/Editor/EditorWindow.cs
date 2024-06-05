using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TruckSimulatorTemplate;

namespace TruckSimulatorTemplate
{
    public class EditorWindow : Editor
    {

        [MenuItem("Window/Truck Simulator Template/Configure Player Trucks", false, -100)]
        public static void OpenPlayerTrucks()
        {
            Selection.activeObject = PlayerTrucks.Instance;
        }

        [MenuItem("Window/Truck Simulator Template/Configure Truck Paints", false, -100)]
        public static void OpenPlayerMaterials()
        {
            Selection.activeObject = TruckPaints.Instance;
        }

        [MenuItem("Window/Truck Simulator Template/Configure Upgradables", false, -100)]
        public static void OpenUpgradables()
        {
            Selection.activeObject = Upgradables.Instance;
        }

        [MenuItem("Window/Truck Simulator Template/Configure Garage Trucks", false, -100)]
        public static void OpenGarageTrucks()
        {
            Selection.activeObject = GarageTrucks.Instance;
        }
         

    }

}

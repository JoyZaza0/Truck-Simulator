using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TruckSimulatorTemplate
{
    [CreateAssetMenu(fileName = "TruckPaint", menuName = "TruckPaint")]
    public class TruckPaints : ScriptableObject
    {
        public static TruckPaints instance;
        public static TruckPaints Instance
        {
            get
            {
                if (instance == null)
                    instance = Resources.Load("TruckPaints") as TruckPaints;
                return instance;
            }

        }
        [System.Serializable]
        public class Paint
        {

            public Material paintMaterial;
            public int paintPrice;

        }
        public Paint[] paint;
    }

}

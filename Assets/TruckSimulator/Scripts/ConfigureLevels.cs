using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///This script is is an entry where you have input your gameplay preferences for each level. This script is read from the LevelsConfiguration.sc script.
///Location: HomeScene "CanvasPanels__.sc>>/EnvironmentPanel0__.sc || EnvironmentPanel1__.sc || EnvironmentPanel2__.sc || EnvironmentPanel3__.sc || EnvironmentPanel4__.sc"
/// </summary>

namespace TruckSimulatorTemplate
{
    public class ConfigureLevels : MonoBehaviour  
    {

        [System.Serializable]
        public class ConfigureLevelsElements
        {
            [Tooltip("eg: expand from lev_0 and drag and drop its starImage here")]
            public Image starsImage;
            [Tooltip("Drag and drop from Projects folder")]
            public Sprite timeImage;
            [Tooltip("Drag and drop from Projects folder")]
            public Sprite levImage;
            [Tooltip("Drag and drop from Projects folder")]
            public Sprite TruckImage;
            [Tooltip("Paste your level description text here")]
            public string levDescription;
            [Tooltip("0 means day. 1 means dawn/dusk. 2 means night ")]
            public int timeOfDay;
            [Tooltip("Time to beat otherwise Game Over!")]
            public int timeToBeat;

            [Tooltip("Refers to the maximum crashes allowed otherwise Game Over!")] //so int "10" means you make truck hit obstacles 10 times above which it will be gameover.
            public int MaxCrashes;
            [Tooltip("Load Index located on 'Truck__.sc' child object of each PlayerTruck")]
            public int LoadIndex;

            [Tooltip("Click 'Truck Index' button below")]
            public int TruckIndex;

            [Tooltip("Click 'EnvTrack Index' button below")]
            public int envTrackIndex;


        }

        public ConfigureLevelsElements[] configureLevelsElements;

    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;



/// <summary>
/// This script allows you to setup time settings for the 3 types of time of the day.
/// Location: on each environment scene (such as Env0 scene) "ISTANTIATORS__.sc"
/// </summary>
namespace TruckSimulatorTemplate
{
    public class TimeOfDayInstantiator : MonoBehaviour
    {
        [Header("-> Set time of day values")]
        [Space]
        [Space]
        public Light directionaLight;
        public float lightStrengthDay, lightStrengthDawndusk, lightStrengthNight;
        public Color fogColorDay, fogColorDawndusk, fogColorNight;
        public float fogDensityDay, fogDensityDawndusk, fogDensityNight;
        public Material skyboxDay, skyboxDawndusk, skyboxNight;
        void Start()
        {
            Debug.Log(GameData.GetTimeOfDay());
            if (GameData.GetTimeOfDay() == 0)
            {

                
                directionaLight.intensity = lightStrengthDay;
                RenderSettings.skybox = skyboxDay;
                RenderSettings.fog = true;

                RenderSettings.fogStartDistance = 0f;
                RenderSettings.fogEndDistance = fogDensityDay;
                RenderSettings.fogColor = fogColorDay;
                RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
              
            }
            else if (GameData.GetTimeOfDay() == 1)
            {
                directionaLight.intensity = lightStrengthDawndusk;
                RenderSettings.skybox = skyboxDawndusk;
                RenderSettings.fog = true;

                RenderSettings.fogStartDistance = 0f;
                RenderSettings.fogEndDistance = fogDensityDawndusk;
                RenderSettings.fogColor = fogColorDawndusk;
                RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
            }
            else if (GameData.GetTimeOfDay() == 2)
            {
                directionaLight.intensity = lightStrengthNight;
                RenderSettings.skybox = skyboxNight;
                RenderSettings.fog = true;

                RenderSettings.fogStartDistance = 0f;
                RenderSettings.fogEndDistance = fogDensityNight;
                RenderSettings.fogColor = fogColorNight;
                RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
            }
        }


        void Update()
        {

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using TruckSimulatorTemplate;

/// <summary>
/// This script is respoonsible for starting the game in the environment scene. It disables the loading screen and other stuff.
/// Location: environment scene (such as Env0 scene ) "STARTER__.sc".
/// </summary>


namespace TruckSimulatorTemplate
{
    public class Starter : MonoBehaviour
    {

        [HideInInspector]
        public bool canStartCountingDown = false;
        [HideInInspector]
        public bool canGameOver = false;
        [HideInInspector]
        public float countdowntime;
        [Header("-> Responsible for assigning Gameplay UIs and \n      starting the Game")]
        [Space]
        [Space]
        public TMP_Text countdownText;
        public TMP_Text crashcountText;
        public TMP_Text crashThresholdText;
        public Slider countdownSlider;

        [HideInInspector]
        public VehicleCrash vehicleCrash;
        public GameOverCaller gameOverCaller;

        [HideInInspector]
        public DeactivateLodingscreen dls;
        public static event Action sendTimeIsZero;
        bool doOnce = false;
        
        void Start()
        {
            countdowntime = GameData.GetCountdownTime();
            countdownSlider.maxValue = GameData.GetCountdownTime();

            Invoke("DisableLoadingscreen", 3f);
           
             

        }
        public void DisableLoadingscreen()
        {

            dls = GameObject.Find("TruckPlayer" + GameData.GetSelectedTruck() + "(Clone)/CanvasCarControl__.sc").GetComponent<DeactivateLodingscreen>();
            dls.DeactivateLoadingScreen();

            canStartCountingDown = true;

            vehicleCrash = GameObject.Find("TruckPlayer" + GameData.GetSelectedTruck() + "(Clone)/Truck__.sc/Front").GetComponent<VehicleCrash>();

        }

        void Update()
        {
            if (canStartCountingDown)
            {
                canGameOver = true;
                countdowntime -= Time.deltaTime;

                countdownText.text = countdowntime.ToString("F0");
                countdownSlider.value = countdowntime;
                crashcountText.text = vehicleCrash.crashcount.ToString();
                crashThresholdText.text = GameData.GetMaxCrashcount().ToString();

            }
            if (!doOnce && countdowntime <= 0)
            {
                
                gameOverCaller.DoWhenTimeIsZero();
                doOnce = true;

            }


        }

    }

}

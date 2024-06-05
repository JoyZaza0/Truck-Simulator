using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TruckSimulatorTemplate;


/// <summary>
/// This script is responsible for calling the finishDisplay panel and calculations when the playerTruck enters the gameobject trigger it sits on.
/// Location:  on each environment scenes (Env0, Env1, etc) "Env0Track0(Clone)/TriggerFinshline__.sc" when game is being played.
/// </summary>
namespace TruckSimulatorTemplate
{
    public class FinishlineTrigger : MonoBehaviour
    {
        Starter starter;
        ScoreAssigner scoreAssigner;
        public GameObject canvasFinishDisplay;
        public TMP_Text timeTakenText;
        public TMP_Text crashcountText;
        public TMP_Text scoreText;
        public Image starsImage;
        [HideInInspector]
        public int totalDistancePoints;
        int totalCrashToAvoid;
        float crashcount;

        GameObject gameplayScreenItems;
        GameObject canvasCarControls;

        float scoreFloat;
        float totalTimeToBeat, totalCrashToBeat;

        void Start()
        {

            totalCrashToAvoid = GameData.GetMaxCrashcount();
        }

        private void OnTriggerEnter(Collider other)
        {


            if (other.CompareTag("PlayerTruck"))
            {
                
                starter = GameObject.Find("STARTER__.sc").GetComponent<Starter>();
                TruckController truckController = starter.vehicleCrash.gameObject.GetComponent<TruckController>();
                truckController.stopTruck = true;
                 
                scoreAssigner = GameObject.Find("SCORER__.sc").GetComponent<ScoreAssigner>();

                gameplayScreenItems = GameObject.Find("Canvas__.sc>>/GameplayScreenItems__.sc>>").gameObject;
                gameplayScreenItems.SetActive(false);

                canvasCarControls = GameObject.Find("TruckPlayer" + GameData.GetSelectedTruck() + "(Clone)/CanvasCarControl__.sc").transform.gameObject;
                canvasCarControls.SetActive(false);

                canvasFinishDisplay.SetActive(true);

                crashcount = starter.vehicleCrash.crashcount;

                crashcountText.text = crashcount.ToString();
                timeTakenText.text = (GameData.GetCountdownTime() - starter.countdowntime).ToString("F0");

                totalDistancePoints = starter.gameOverCaller.totalDistancePoints;                

                float distanceCovered = PlayerPrefs.GetInt("distanceCovered");

                scoreFloat = ((((float)distanceCovered / (float)totalDistancePoints) * (3f / 4f)) + (1 - ((float)crashcount / (float)totalCrashToAvoid)) * (1f / 4f)) * 100f;

                scoreText.text = scoreFloat.ToString("F0");

                scoreAssigner.starsImage = this.starsImage;

                scoreAssigner.AssignScoreForFinishingLine(scoreFloat);

                 
                 
            }



        }
    }
}


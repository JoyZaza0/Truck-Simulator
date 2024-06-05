using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TruckSimulatorTemplate;

/// <summary>
/// This script is responsible for calling the GameOverPanel when the countdown time (timeToBeat) comes to 0.
/// Location:  on each environment scenes (Env0, Env1, etc) "GAMEOVER__.sc" when game is being played.
/// </summary>

namespace TruckSimulatorTemplate
{
    public class GameOverCaller : MonoBehaviour
    {
        public Starter starter;
        public ScoreAssigner scoreAssigner;
        public GameObject gameoverPanel;
        public TMP_Text timeTakenText;
        public TMP_Text crashCountText;
        public TMP_Text causeOfLoseText;
        public Image starsImage;
        public GameObject gameplayScreenItems;
        public TMP_Text scoreText;

        int totalCrashToAvoid;
        int crashcount;
        float timetaken;
        float scoreFloat;
        int distanceCovered;
        [HideInInspector]
        public int totalDistancePoints;

        void Start()
        {
            Starter.sendTimeIsZero += DoWhenTimeIsZero;

            totalCrashToAvoid = GameData.GetMaxCrashcount();



        }
        public void DoWhenTimeIsZero()
        {
            starter.vehicleCrash.gameObject.GetComponent<TruckController>().stopTruck = true;

            starter.canStartCountingDown = false;
            gameoverPanel.SetActive(true);

            timeTakenText.text = (GameData.GetCountdownTime() - starter.countdowntime).ToString("F0");

            crashcount = starter.vehicleCrash.crashcount;
            crashCountText.text = crashcount.ToString();

            starter.dls.transform.gameObject.SetActive(false);
            gameplayScreenItems.SetActive(false);



            if (starter.countdowntime <= 0 && starter.canGameOver)
            {
                causeOfLoseText.text = "you failed to beat the time!";


            }
            if (starter.vehicleCrash)
            {
                if (starter.vehicleCrash.crashcount > GameData.GetMaxCrashcount() && starter.canGameOver)
                {

                    causeOfLoseText.text = "you have crash too many times!";

                }
            }
            distanceCovered = PlayerPrefs.GetInt("distanceCovered");

            scoreFloat = ((((float)distanceCovered / (float)totalDistancePoints) * (3f / 4f)) + (1 - ((float)crashcount / (float)totalCrashToAvoid)) * (1f / 4f)) * 100f;

            scoreText.text = scoreFloat.ToString();

            scoreAssigner.starsImage = this.starsImage;

            scoreAssigner.AssignScoreForGameOver(scoreFloat);


        }




    }

}

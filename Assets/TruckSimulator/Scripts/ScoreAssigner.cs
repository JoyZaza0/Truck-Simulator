using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TruckSimulatorTemplate;

/// <summary>
/// This script calculates and assigns the stars after completion of each level.
/// Location: on each Environment scene (such as Env0) "SCORER__.sc"
/// </summary>

namespace TruckSimulatorTemplate
{
    public class ScoreAssigner : MonoBehaviour
    {
        public GameOverCaller gameOverCaller;
        public Starter starter;
        [HideInInspector]
        public Image starsImage;
        public Sprite[] starsSprites;
        float totalTimeToBeat, crashcount, totalCrashToBeat;
        float timetaken;
        float scoreFloat;
        public int highestCoinsAward = 40;
        public int higherCoinsAward = 30;
        public int highCoinsAward = 20;
        public int lowCoinsAward = 10;   
        int initialCoinsAmount;
        void Start()
        {
            totalTimeToBeat = GameData.GetCountdownTime();
            totalCrashToBeat = GameData.GetMaxCrashcount();
            initialCoinsAmount = GameData.GetCoinsAmount();
        }
        public void AssignScoreForGameOver(float scoreFloat)
        {


            Calculate(scoreFloat);
            GameData.SetLevelScore(GameData.GetSelectedEnv(), GameData.GetSelectedLevel(), scoreFloat);


        }
        public void AssignScoreForFinishingLine(float scoreFloat)
        {


            Calculate(scoreFloat);
            GameData.SetLevelScore(GameData.GetSelectedEnv(), GameData.GetSelectedLevel(), scoreFloat);

        }

        public void Calculate(float scoreFloat)
        {

            if (scoreFloat <= 10 && scoreFloat >= 1)
            {
                starsImage.sprite = starsSprites[1];  GameData.SetCoinsAmount(initialCoinsAmount + lowCoinsAward);
            }
            else if (scoreFloat <= 20 && scoreFloat >= 10)
            {
                starsImage.sprite = starsSprites[1];  GameData.SetCoinsAmount(initialCoinsAmount + lowCoinsAward);   
            }
            else if (scoreFloat <= 30 && scoreFloat >= 20)
            {
                starsImage.sprite = starsSprites[2];  GameData.SetCoinsAmount(initialCoinsAmount + lowCoinsAward);
            }
            else if (scoreFloat <= 40 && scoreFloat >= 30)
            {
                starsImage.sprite = starsSprites[3];  GameData.SetCoinsAmount(initialCoinsAmount + highCoinsAward);
            }
            else if (scoreFloat <= 50 && scoreFloat >= 40)
            {
                starsImage.sprite = starsSprites[4];  GameData.SetCoinsAmount(initialCoinsAmount + highCoinsAward);
            }
            else if (scoreFloat <= 60 && scoreFloat >= 50)
            {
                starsImage.sprite = starsSprites[5];  GameData.SetCoinsAmount(initialCoinsAmount + highCoinsAward);
            }
            else if (scoreFloat <= 70 && scoreFloat >= 60)
            {
                starsImage.sprite = starsSprites[6];  GameData.SetCoinsAmount(initialCoinsAmount + higherCoinsAward);
            }
            else if (scoreFloat <= 80 && scoreFloat >= 70)
            {
                starsImage.sprite = starsSprites[7];  GameData.SetCoinsAmount(initialCoinsAmount + higherCoinsAward);
            }
            else if (scoreFloat <= 90 && scoreFloat >= 80)
            {
                starsImage.sprite = starsSprites[8];  GameData.SetCoinsAmount(initialCoinsAmount + higherCoinsAward);
            }
            else if (scoreFloat <= 99 && scoreFloat >= 90)
            {
                starsImage.sprite = starsSprites[9];  GameData.SetCoinsAmount(initialCoinsAmount + higherCoinsAward);
            }
            else if (scoreFloat == 100)
            {
                 
                starsImage.sprite = starsSprites[10];  GameData.SetCoinsAmount(initialCoinsAmount + highestCoinsAward);
            }
            else

            {
                starsImage.sprite = starsSprites[0];
            }

        }

    }

}

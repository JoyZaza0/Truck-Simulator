using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TruckSimulatorTemplate;



/// <summary>
/// This script assigns your level star scores to each level when their environment panels are opened in the HomeScene.
///Location: HomeScene "CanvasPanels__.sc>>/EnvironmentPanel0__.sc || EnvironmentPanel1__.sc || EnvironmentPanel2__.sc || EnvironmentPanel3__.sc || EnvironmentPanel4__.sc"
/// </summary>

namespace TruckSimulatorTemplate
{
    public class LevelsStarsAssign : MonoBehaviour
    {
        public UiGameObjects uiGameObjects;
        float scoreFloat;
        public ConfigureLevels configureLevels;
        [HideInInspector]
        public int numberOfLevels;

        void OnEnable()
        {

            Debug.Log(GameData.GetLevelScore(GameData.GetSelectedEnv(), 1));
            numberOfLevels = configureLevels.configureLevelsElements.Length;

            for (int i = 0; i < numberOfLevels; i++)
            {
                scoreFloat = GameData.GetLevelScore(GameData.GetSelectedEnv(), i);

                if (scoreFloat <= 10 && scoreFloat >= 1)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[1];
                }
                else if (scoreFloat <= 20 && scoreFloat >= 10)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[1];
                }
                else if (scoreFloat <= 30 && scoreFloat >= 20)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[2];
                }
                else if (scoreFloat <= 40 && scoreFloat >= 30)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[3];
                }
                else if (scoreFloat <= 50 && scoreFloat >= 40)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[4];
                }
                else if (scoreFloat <= 60 && scoreFloat >= 50)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[5];
                }
                else if (scoreFloat <= 70 && scoreFloat >= 60)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[6];
                }
                else if (scoreFloat <= 80 && scoreFloat >= 70)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[7];
                }
                else if (scoreFloat <= 90 && scoreFloat >= 80)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[8];
                }
                else if (scoreFloat <= 99 && scoreFloat >= 90)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[9];
                }
                else if (scoreFloat == 100)
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[10];
                }
                else
                {
                    configureLevels.configureLevelsElements[i].starsImage.sprite = uiGameObjects.starSprites[0];
                }
            }
        }


        void Update()
        {

        }
    }

}

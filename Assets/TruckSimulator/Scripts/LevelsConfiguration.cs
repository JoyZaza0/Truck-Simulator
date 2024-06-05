using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TruckSimulatorTemplate;



/// <summary>
/// This script assigns your preferred settings when the Play button is pressed .
/// Location : HomeScene "LEVELS__.sc".
/// </summary>

namespace TruckSimulatorTemplate
{
    public class LevelsConfiguration : MonoBehaviour
    {

        public UiGameObjects uiGameObjects;

        ConfigureLevels configureLevels;
        int levelnumber;
        int selectedEnvnumber;
        bool doOnce = false;
        float scoreFloat;

        


        public void LevelPressed(int levelnumber)
        {
            this.levelnumber = levelnumber;
            selectedEnvnumber = GameData.GetSelectedEnv();           

            configureLevels = uiGameObjects.envPlayLevelsPanels[selectedEnvnumber].GetComponent<ConfigureLevels>();

            configureLevels.transform.GetComponent<SetDefaultLevel>().playButton.SetActive(true);

            uiGameObjects.timeOfdayImage.sprite = configureLevels.configureLevelsElements[levelnumber].timeImage;
            uiGameObjects.levDescriptionImage.sprite = configureLevels.configureLevelsElements[levelnumber].levImage;
            uiGameObjects.levTruckImageToUse.sprite = configureLevels.configureLevelsElements[levelnumber].TruckImage;
            uiGameObjects.levDescriptionText.text = configureLevels.configureLevelsElements[levelnumber].levDescription;

            uiGameObjects.levMaxCountDownText.text = configureLevels.configureLevelsElements[levelnumber].timeToBeat.ToString() + "  seconds";
            uiGameObjects.levMaxCrashCountText.text = configureLevels.configureLevelsElements[levelnumber].MaxCrashes.ToString();

            GameData.SetSelectedLevel(levelnumber);
            GameData.SetTimeOfDay(configureLevels.configureLevelsElements[levelnumber].timeOfDay);
            GameData.SetCountdownTime(configureLevels.configureLevelsElements[levelnumber].timeToBeat);
            GameData.SetMaxCrashCount(configureLevels.configureLevelsElements[levelnumber].MaxCrashes);
            GameData.SetSelectedTruck(configureLevels.configureLevelsElements[levelnumber].TruckIndex);
            GameData.SetSelectedEnvTrack(configureLevels.configureLevelsElements[levelnumber].envTrackIndex);
            GameData.SetTypeOfLoad(GameData.GetSelectedTruck(), configureLevels.configureLevelsElements[levelnumber].LoadIndex);

        }

        public void PlaynowPressed()
        {
            foreach (GameObject panel in uiGameObjects.envPlayLevelsPanels)
            {
                panel.SetActive(false);
            }
            uiGameObjects.levelDescriptionPanel.SetActive(false);
            uiGameObjects.loadingscreenPanel.SetActive(true);
            SceneManager.LoadScene(GameData.GetSelectedEnv() + 1);

            GameData.SetJustPlayedLevel(selectedEnvnumber, GameData.GetSelectedLevel());

        }
 

    }

}

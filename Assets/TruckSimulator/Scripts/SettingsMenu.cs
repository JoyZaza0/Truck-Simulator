using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TruckSimulatorTemplate;


/// <summary>
/// This script is for the settings of the game.
/// Location: HomeScene "SETTINGS__.sc".  And on environments scene (Such as Env0 scene) "Canvas__.sc>>/GameplayScreenItems__.sc>>/pauseBtn__.sc".
/// </summary>
namespace TruckSimulatorTemplate
{
    public class SettingsMenu : MonoBehaviour
    {
        public GameObject pausePanel;  //leave this empty in the inspector if this opened in the HomeScene, as there is no PausePanel in the HomeScene.
        [HideInInspector]
        public GameObject controlsButtons; //assigned from DeactivateLodingscreen.cs in line 21.
        public GameObject gamePlayScreenItems;
        public GameObject controlsPanel, audioPanel, graphicsPanel, settingsPanel;
        public GameObject[] controlTicks;
        public GameObject[] graphicsTicks;
        public AudioMixer audioMixer;
        public Slider sfxslider, musicslider;


        void Start()
        {

            sfxslider.value = GameData.GetSfxVolume();
            musicslider.value = GameData.GetMusicVolume();

            if (SceneManager.GetActiveScene().buildIndex != 0)
                gamePlayScreenItems = transform.parent.gameObject;


        }

        public void RestartPressed()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        public void PausePressed()
        {
            controlsButtons.SetActive(false);

            pausePanel.SetActive(true);

            gamePlayScreenItems.SetActive(false);

            Time.timeScale = 0;
        }
        public void SettingsPressed()
        {
            settingsPanel.SetActive(true);
        }

        public void ResumePressed()
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            controlsButtons.SetActive(true);
            gamePlayScreenItems.SetActive(true);
        }

        public void HomePressed()
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetString("SwitchToHomePanel", "yes");
        }
        public void backSettingsPressed()
        {
            settingsPanel.SetActive(false);
            // controlsButtons.SetActive(true);

        }
        //==================================================================================
        public void ControlsPressed()
        {
            controlsPanel.SetActive(true);
            DeactivatecontrolTicks();
            if (GameData.GetSelectedControltype() == "arrows")
            {
                controlTicks[0].SetActive(true);
            }
            else if (GameData.GetSelectedControltype() == "tilt")
            {
                controlTicks[1].SetActive(true);
            }
            else if (GameData.GetSelectedControltype() == "steerwheel")
            {
                controlTicks[2].SetActive(true);
            }
        }
        public void ControlArrows()
        {
            GameData.SetSelectedControltype("arrows");
            DeactivatecontrolTicks();
            controlTicks[0].SetActive(true);
        }
        public void ControlTilt()
        {
            DeactivatecontrolTicks();
            GameData.SetSelectedControltype("tilt");
            controlTicks[1].SetActive(true);
        }
        public void ControlSteerwheel()
        {
            DeactivatecontrolTicks();
            GameData.SetSelectedControltype("steerwheel");
            controlTicks[2].SetActive(true);
        }
        public void backControls()
        {
            controlsPanel.SetActive(false);
        }
        public void DeactivatecontrolTicks()
        {
            foreach (GameObject tick in controlTicks)
            {
                tick.SetActive(false);
            }
        }

        //==================================================================================
        public void AudioPressed()
        {
            audioPanel.SetActive(true);
        }
        public void backAudio()
        {
            audioPanel.SetActive(false);
        }
        public void SetSfxVolume()
        {
            float sfxvolume = sfxslider.value;
            audioMixer.SetFloat("Sfx", Mathf.Log10(sfxvolume) * 20);
            GameData.SetSfxVolume(sfxvolume);
        }
        public void SetMusicVolume()
        {
            float musicvolume = musicslider.value;
            audioMixer.SetFloat("music", Mathf.Log10(musicvolume) * 20);
            GameData.SetMusicVolume(musicvolume);
        }
        //=====================================================================================
        public void GraphicsPressed()
        {
            graphicsPanel.SetActive(true);
            DeactivategraphicsTicks();
            if (GameData.GetQuality() == 0)
            {
                graphicsTicks[0].SetActive(true);
            }
            else if (GameData.GetQuality() == 1)
            {
                graphicsTicks[1].SetActive(true);
            }
            else
            {
                graphicsTicks[2].SetActive(true);
            }

        }
        public void LowQualityPressed()
        {
            DeactivategraphicsTicks();
            QualitySettings.SetQualityLevel(0);
            GameData.SetQuality(0);
            graphicsTicks[0].SetActive(true);
        }
        public void MediumQualityPressed()
        {
            DeactivategraphicsTicks();
            QualitySettings.SetQualityLevel(1);
            GameData.SetQuality(1);
            graphicsTicks[1].SetActive(true);
        }
        public void HighQualityPressed()
        {
            DeactivategraphicsTicks();
            QualitySettings.SetQualityLevel(2);
            GameData.SetQuality(2);
            graphicsTicks[2].SetActive(true);
        }
        public void backGraphics()
        {

            graphicsPanel.SetActive(false);
        }
        public void DeactivategraphicsTicks()
        {
            foreach (GameObject tick in graphicsTicks)
            {
                tick.SetActive(false);
            }
        }


    }

}

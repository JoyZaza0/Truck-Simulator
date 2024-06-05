using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///This script stores the game data. All are in playerPrefs.
/// Lacation: Since they are static methods, it does not sit on any gameObject. 
/// </summary>
namespace TruckSimulatorTemplate
{
    public class GameData : MonoBehaviour
    {
        public static void SetFreshGameStatus(string yesOrno)
        {
            PlayerPrefs.SetString("IsEntireGameReset", yesOrno);
        }
        public static string GetFreshGameStatus()
        {
            return PlayerPrefs.GetString("IsEntireGameReset");

        }

        //=====================================================================================
        public static void SetSelectedControltype(string controltype)
        {
            PlayerPrefs.SetString("ControlTypeSelected", controltype);
        }
        public static string GetSelectedControltype()
        {
            return PlayerPrefs.GetString("ControlTypeSelected");
        }
        //=====================================================================================
        public static void SetPlayerTruckProperties(int playerTruckID, int paintId, int sunshadeId, int bullbarId, int topbarId, int lowbarId, int otherId)
        {
            int result = int.Parse(paintId.ToString() + sunshadeId.ToString() + bullbarId.ToString() + topbarId.ToString() + lowbarId.ToString() + otherId.ToString());
            PlayerPrefs.SetInt("PlayerTruckID_" + playerTruckID, result);
        }

        public static int GetPlayerTruckProperties(int playerTruckID)
        {
            return PlayerPrefs.GetInt("PlayerTruckID_" + playerTruckID);
        }

        //=====================================================================================

        public static void SetSelectedEnvTrack(int envTrackIndex)
        {
            PlayerPrefs.SetInt("WhatIsSelectedEnvTrack", envTrackIndex);
        }
        public static int GetSelectedEnvTrack()
        {
            return PlayerPrefs.GetInt("WhatIsSelectedEnvTrack");

        }
        public static void SetSelectedEnv(int envnumber)
        {
            PlayerPrefs.SetInt("WhatIsSelectedEnv", envnumber);
        }
        public static int GetSelectedEnv()
        {
            return PlayerPrefs.GetInt("WhatIsSelectedEnv");

        }
        //========================================================================================
        public static void SetSelectedTruck(int trucknumber)
        {
            PlayerPrefs.SetInt("WhatTruckIsSelected", trucknumber);
        }
        public static int GetSelectedTruck()
        {
            return PlayerPrefs.GetInt("WhatTruckIsSelected");
        }

        //========================================================================================
        public static void SetCoinsAmount(int coinsamount)
        {
            PlayerPrefs.SetInt("WhatAmountOfCoinsCurrent", coinsamount);
        }
        public static int GetCoinsAmount()
        {
            return PlayerPrefs.GetInt("WhatAmountOfCoinsCurrent");
        }
        //=====================================================================================  
        public static void SetCountdownTime(int countdowntime)
        {
            PlayerPrefs.SetInt("WhatIstheCountdownTime", countdowntime);
        }
        public static int GetCountdownTime()
        {
            return PlayerPrefs.GetInt("WhatIstheCountdownTime");
        }
        public static void SetMaxCrashCount(int maxcrashcount)
        {
            PlayerPrefs.SetInt("WhatIstheMaxCrashcount", maxcrashcount);
        }
        public static int GetMaxCrashcount()
        {
            return PlayerPrefs.GetInt("WhatIstheMaxCrashcount");
        }
        //=====================================================================================

        public static void SetPaintPadlockStatus(int paintIndex, string yesOrno)
        {
            PlayerPrefs.SetString("IsPaintPadlocked" + paintIndex, yesOrno);

        }
        public static string GetPaintLockImageStatus(int paintIndex)
        {
            return PlayerPrefs.GetString("IsPaintPadlocked" + paintIndex);
        }
        //======================================================================================
        public static void SetSunshadePadlockStatus(int padlockIndex, string yesOrno)
        {
            PlayerPrefs.SetString("IsSunshadePadlocked" + padlockIndex, yesOrno);
        }
        public static string GetSunshadePadlockStatus(int padlockIndex)
        {
            return PlayerPrefs.GetString("IsSunshadePadlocked" + padlockIndex);
        }

        public static void SetBullbarPadlockStatus(int padlockIndex, string yesOrno)
        {
            PlayerPrefs.SetString("IsBullbarPadlocked" + padlockIndex, yesOrno);
        }
        public static string GetBullbarPadlockStatus(int padlockIndex)
        {
            return PlayerPrefs.GetString("IsBullbarPadlocked" + padlockIndex);
        }

        public static void SetTopbarPadlockStatus(int padlockIndex, string yesOrno)
        {
            PlayerPrefs.SetString("IsTopbarPadPadlocked" + padlockIndex, yesOrno);
        }
        public static string GetTopbarPadlockStatus(int padlockIndex)
        {
            return PlayerPrefs.GetString("IsTopbarPadPadlocked" + padlockIndex);
        }

        public static void SetLowbarPadlockStatus(int padlockIndex, string yesOrno)
        {
            PlayerPrefs.SetString("IsLowbarPadPadlocked" + padlockIndex, yesOrno);
        }
        public static string GetLowbarPadlockStatus(int padlockIndex)
        {
            return PlayerPrefs.GetString("IsLowbarPadPadlocked" + padlockIndex);
        }

        public static void SetOtherPadlockStatus(int padlockIndex, string yesOrno)
        {
            PlayerPrefs.SetString("IsOtherPadPadlocked" + padlockIndex, yesOrno);
        }
        public static string GetOtherPadlockStatus(int padlockIndex)
        {
            return PlayerPrefs.GetString("IsOtherPadPadlocked" + padlockIndex);
        }


        //=====================================================================================
        public static void SetSelectedLevel(int levelnumber)
        {
            PlayerPrefs.SetInt("WhatlevelIsSelected", levelnumber);
        }
        public static int GetSelectedLevel()
        {
            return PlayerPrefs.GetInt("WhatlevelIsSelected");
        }
        public static void SetTimeOfDay(int timeOfDayIndex)
        {
            PlayerPrefs.SetInt("WhatTimeOfDay", timeOfDayIndex);
        }
        public static int GetTimeOfDay()
        {
            return PlayerPrefs.GetInt("WhatTimeOfDay");

        }

        //======================================================================================

        public static void SetSfxVolume(float sfxvolume)
        {
            PlayerPrefs.SetFloat("sfxVolume", sfxvolume);
        }
        public static float GetSfxVolume()
        {
            return PlayerPrefs.GetFloat("sfxVolume");
        }
        public static void SetMusicVolume(float musicvolume)
        {
            PlayerPrefs.SetFloat("musicVolume", musicvolume);
        }
        public static float GetMusicVolume()
        {
            return PlayerPrefs.GetFloat("musicVolume");
        }
        //======================================================================================
        public static void SetQuality(float qualitynumber)
        {
            PlayerPrefs.SetFloat("qualitynumber", qualitynumber);
        }
        public static float GetQuality()
        {
            return PlayerPrefs.GetFloat("qualitynumber");
        }
        //======================================================================================
        public static void SetJustPlayedLevel(int environment, int level)
        {
            PlayerPrefs.SetInt("Whatlevelwasjustplayed" + environment, level);
        }
        public static int GetJustPlayedLevel(int environment)
        {
            return PlayerPrefs.GetInt("Whatlevelwasjustplayed" + environment);
        }

        //-----------------------------------------------------------------------------------------
        public static void SetLevelScore(int envnumber, int levelnumber, float score)
        {
            PlayerPrefs.SetFloat("WhatScoreIsThisLevel" + envnumber + levelnumber, score);
        }
        public static float GetLevelScore(int envnumber, int levelnumber)
        {
            return PlayerPrefs.GetFloat("WhatScoreIsThisLevel" + envnumber + levelnumber);
        }
        //-----------------------------------------------------------------------------------------
        public static void SetTypeOfLoad(int trucknumber, int loadIndex)
        {
            PlayerPrefs.SetInt("WhatTypeOfLoadIsSelected" + trucknumber, loadIndex);
        }
        public static int GetTypeOfLoad(int trucknumber)
        {
            return PlayerPrefs.GetInt("WhatTypeOfLoadIsSelected" + trucknumber);
        }
        //-------------------------------------------------------------------------------------------
         

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TruckSimulatorTemplate;


/// <summary>
/// This script is for shopping for coins.
/// Location: "COINS__.sc".
/// </summary>
namespace TruckSimulatorTemplate
{
    public class ShopCoins : MonoBehaviour
    {
        public UiGameObjects uiGameObjects;
        int currentCoinsAmount;
        int newCoinsAmount;
        public TMP_Text coinsText;


        public void GetCoinsPressed(int coinsAmountToGet)
        {
            //write code for what happens when this watch ads for coins is pressed. 
            //That is your...
            newCoinsAmount = currentCoinsAmount + coinsAmountToGet;
            UpdateGameDataCoins();
        }


        public void WatchAdForFreeCoins(int freeCoinsAmountToGet)
        {
            //write code for what happens when this watch ads for coins is pressed. 
            //That is your...
            UpdateGameDataCoins();

        }

        public void UpdateGameDataCoins()
        {

            GameData.SetCoinsAmount(newCoinsAmount);
            coinsText.text = GameData.GetCoinsAmount().ToString();
        }


    }
}


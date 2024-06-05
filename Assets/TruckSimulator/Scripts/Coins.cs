using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
///This script reads from the saved coins amount in GameData and displays it as text.
///Location: "COINS__.sc".
/// </summary>

namespace TruckSimulatorTemplate
{
    public class Coins : MonoBehaviour
    {
        public TMP_Text coinsText;
        void Start()
        {
            coinsText.text = GameData.GetCoinsAmount().ToString();  
        }


        void Update()
        {

        }
    }

}

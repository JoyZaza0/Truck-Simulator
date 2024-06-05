using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;



/// <summary>
/// This script translates the saved playerTruck properties in GameData.GetPlayerTruckProperties() playerPrefs into specific properties where they read from 
/// throughout the game.
/// Location : HomeScene "PlayerTruckProperties__.sc".
/// </summary>
namespace TruckSimulatorTemplate
{
    public class TruckProperties : MonoBehaviour
    {


        [System.Serializable]
        public class PlayerTruckProperties
        {

            public int paintId;
            public int sunshadeId;
            public int bullbarId;
            public int topbarId;
            public int lowbarId;
            public int otherId;


        }

        public PlayerTruckProperties[] playerTruckProperties;


        public void Start()
        {

           // GameData.SetPlayerTruckProperties(0,1,2,3,4,2,1); 

            for (int i = 0; i < playerTruckProperties.Length; i++)
            {

                int playerTruckID = GameData.GetPlayerTruckProperties(i);
                
                playerTruckProperties[i].paintId = (playerTruckID / (int)Mathf.Pow(10, 6 - 1) % 10);

                playerTruckProperties[i].sunshadeId = (playerTruckID / (int)Mathf.Pow(10, 5 - 1) % 10);

                playerTruckProperties[i].bullbarId = (playerTruckID / (int)Mathf.Pow(10, 4 - 1) % 10);

                playerTruckProperties[i].topbarId = (playerTruckID / (int)Mathf.Pow(10, 3 - 1) % 10);

                playerTruckProperties[i].lowbarId = (playerTruckID / (int)Mathf.Pow(10, 2 - 1) % 10);

                playerTruckProperties[i].otherId = (playerTruckID / (int)Mathf.Pow(10, 1 - 1) % 10);

            }


        }
        public void UpdateProperties()
        {
            int selectedPlayerTruck = GameData.GetSelectedTruck();

            GameData.SetPlayerTruckProperties
            
            (
                selectedPlayerTruck,

            playerTruckProperties[selectedPlayerTruck].paintId,

            playerTruckProperties[selectedPlayerTruck].sunshadeId,

            playerTruckProperties[selectedPlayerTruck].bullbarId,

            playerTruckProperties[selectedPlayerTruck].topbarId,

            playerTruckProperties[selectedPlayerTruck].lowbarId,

            playerTruckProperties[selectedPlayerTruck].otherId

            );
        }

       



    }

}


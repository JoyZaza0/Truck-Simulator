using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TruckSimulatorTemplate;

/// <summary>
///This scipt is responsible for buying upgradables when the "Buy" button is clicked. 
///Location: "CanvasPanels__.sc>>/CUSTOMISATIONPanel/BuyBtn".
/// </summary>
namespace TruckSimulatorTemplate
{
    public class BuyUpgradables : MonoBehaviour
    {
        public UiGameObjects uiGameObjects;
        TruckProperties truckProperties;
        int coinsAmountLeft;
        public Upgradables upgradables;
        DisableUpgradblePadlocks disableUpgradblePadlocks;
        [HideInInspector]
        public int sunshadeIndex, bullbarIndex, topbarIndex, lowbarIndex, otherIndex;
        [HideInInspector]
        public int buyInt;
    
        void Start()
        {
            truckProperties = GameObject.Find("PlayerTrucksProperties__.sc").GetComponent<TruckProperties>();
            disableUpgradblePadlocks = GetComponent<DisableUpgradblePadlocks>();
        }
        public void BuyUpgradable()
        {
            if (buyInt == 0)
            {
                if (GameData.GetCoinsAmount() >= upgradables.upgradable[sunshadeIndex].priceOfSunshade)
                {
                    coinsAmountLeft = GameData.GetCoinsAmount() - upgradables.upgradable[sunshadeIndex].priceOfSunshade;
                    uiGameObjects.coinsText.text = coinsAmountLeft.ToString();
                    GameData.SetCoinsAmount(coinsAmountLeft);

                    disableUpgradblePadlocks.sunshadePadlocks[sunshadeIndex].SetActive(false);
                    GameData.SetSunshadePadlockStatus(sunshadeIndex, "yes");

                    truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].sunshadeId = sunshadeIndex;
                    truckProperties.UpdateProperties();
                }
                else
                {
                    uiGameObjects.notEnoughCoinsNotification.SetActive(true);
                }
            }
            else if (buyInt == 1)
            {
                if (GameData.GetCoinsAmount() >= upgradables.upgradable[bullbarIndex].priceOfSunshade)
                {
                    coinsAmountLeft = GameData.GetCoinsAmount() - upgradables.upgradable[bullbarIndex].priceOfbullbar;
                    uiGameObjects.coinsText.text = coinsAmountLeft.ToString();
                    GameData.SetCoinsAmount(coinsAmountLeft);

                    disableUpgradblePadlocks.bullbarPadlocks[bullbarIndex].SetActive(false);
                    GameData.SetBullbarPadlockStatus(bullbarIndex, "yes");

                    truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].bullbarId = bullbarIndex;
                    truckProperties.UpdateProperties();
                }
                else
                {
                    uiGameObjects.notEnoughCoinsNotification.SetActive(true);
                }
            }
            else if (buyInt == 2)
            {
                if (GameData.GetCoinsAmount() >= upgradables.upgradable[topbarIndex].priceOftopbar)
                {
                    coinsAmountLeft = GameData.GetCoinsAmount() - upgradables.upgradable[topbarIndex].priceOftopbar;
                    uiGameObjects.coinsText.text = coinsAmountLeft.ToString();
                    GameData.SetCoinsAmount(coinsAmountLeft);

                    disableUpgradblePadlocks.topbarPadlocks[topbarIndex].SetActive(false);
                    GameData.SetTopbarPadlockStatus(topbarIndex, "yes");

                    truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].topbarId = topbarIndex;
                    truckProperties.UpdateProperties();
                }
                else
                {
                    uiGameObjects.notEnoughCoinsNotification.SetActive(true);
                }
            }
            else if (buyInt == 3)
            {
                if (GameData.GetCoinsAmount() >= upgradables.upgradable[lowbarIndex].priceOflowbar)
                {
                    coinsAmountLeft = GameData.GetCoinsAmount() - upgradables.upgradable[lowbarIndex].priceOflowbar;
                    uiGameObjects.coinsText.text = coinsAmountLeft.ToString();
                    GameData.SetCoinsAmount(coinsAmountLeft);

                    disableUpgradblePadlocks.lowbarPadlocks[lowbarIndex].SetActive(false);
                    GameData.SetLowbarPadlockStatus(lowbarIndex, "yes");

                    truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].lowbarId = lowbarIndex;
                    truckProperties.UpdateProperties();
                }
                else
                {
                    uiGameObjects.notEnoughCoinsNotification.SetActive(true);
                }
            }
            else if (buyInt == 4)
            {
                if (GameData.GetCoinsAmount() >= upgradables.upgradable[otherIndex].priceOfother)
                {
                    coinsAmountLeft = GameData.GetCoinsAmount() - upgradables.upgradable[otherIndex].priceOfother;
                    uiGameObjects.coinsText.text = coinsAmountLeft.ToString();
                    GameData.SetCoinsAmount(coinsAmountLeft);

                    disableUpgradblePadlocks.otherPadlocks[otherIndex].SetActive(false);
                    GameData.SetOtherPadlockStatus(otherIndex, "yes");

                    truckProperties.playerTruckProperties[GameData.GetSelectedTruck()].otherId = otherIndex;
                    truckProperties.UpdateProperties();
                }
                else
                {
                    uiGameObjects.notEnoughCoinsNotification.SetActive(true);
                }
            }


        }


    }

}


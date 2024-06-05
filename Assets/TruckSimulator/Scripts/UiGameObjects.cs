using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TruckSimulatorTemplate
{

    /// <summary>
    /// This script contains all or almost all GUI gamebjects in this HomeScene.
    /// Location: HomeScene UIGAMEOBJECTS__.sc".
    /// </summary>
    public class UiGameObjects : MonoBehaviour
    {
        public GameObject FreshgamePanel, EntryPanel, HomePanel, GaragePanel, CustomisationPanel, ShopPanel, GameWillQuitPanelFresh, GameWillQuitPanelEntry, FreeCoinsPanel, AboutPanel,
        CoinsAtTheTopPanel, levelDescriptionPanel, loadingscreenPanel;
        public GameObject garagePlace;
        public GameObject[] envPlayLevelsPanels;
        public GameObject[] environmentImages;
        public TMP_Text coinsText;
        public GameObject notEnoughCoinsNotification;
 
        public Sprite[] starSprites;

        public Image timeOfdayImage;
        public Image levDescriptionImage;
        public TMP_Text levDescriptionText;
        public TMP_Text levMaxCountDownText;
        public TMP_Text levMaxCrashCountText;
        public Image levTruckImageToUse;
        public GameObject uiCamera;
        [HideInInspector]
        public GameObject truckInGarage;
        public GameObject[] upGradableItems;



        void Start()
        {
            Time.timeScale = 1f;
        }

    }

}

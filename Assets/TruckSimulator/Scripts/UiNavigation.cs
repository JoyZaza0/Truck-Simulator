using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using TruckSimulatorTemplate;

namespace TruckSimulatorTemplate
{

    /// <summary>
    /// This script is responsible for UI navigations such as button presses in the HomeScene.
    /// Location : "UINAVIGATION__.sc".
    /// </summary>
    public class UiNavigation : MonoBehaviour
    {
        public UiGameObjects uiGameObjects;  //reference to the GUI (buttons) to be pressed. 
        GameObject specsPanel;

        //===============================================================================================
        public void YesAcceptPolicyPressed()
        {
            uiGameObjects.FreshgamePanel.SetActive(false);
            uiGameObjects.EntryPanel.SetActive(true);
            GameData.SetFreshGameStatus("no");

        }

        public void NoAcceptPolicyPressed()
        {
            uiGameObjects.GameWillQuitPanelFresh.SetActive(true);
        }

        public void YesQuitPressed()
        {
            Application.Quit();
        }
        public void NoQuitPressed()
        {
            uiGameObjects.GameWillQuitPanelFresh.SetActive(false);
            uiGameObjects.FreshgamePanel.SetActive(true);
        }
        //===============================================================================================
        public void StartgamePressed()
        {
            uiGameObjects.EntryPanel.SetActive(false);
            uiGameObjects.HomePanel.SetActive(true);
            uiGameObjects.CoinsAtTheTopPanel.SetActive(true);
        }
        public void QuitGamePressed()
        {
            uiGameObjects.GameWillQuitPanelEntry.SetActive(true);
        }
        public void YesQuit()
        {
            Application.Quit();
        }
        public void NoQuit()
        {
            uiGameObjects.GameWillQuitPanelEntry.SetActive(false);
        }
        public void AboutPressed()
        {
            uiGameObjects.AboutPanel.SetActive(true);
        }
        public void CancelAboutPressed()
        {
            uiGameObjects.AboutPanel.SetActive(false);
        }
        public void websitePressed()
        {
            Application.OpenURL("https://sites.google.com/view/openwoldgames/%D0%B3%D0%BB%D0%B0%D0%B2%D0%BD%D0%B0%D1%8F");
        }
        public void emailPressed()
        {
            SendEmail("emailaddress@gmail.com", "testing", "i want to report a bug");
        }
        public void SendEmail(string emailAddress, string emailSubject, string emailBody)
        {
            emailSubject = System.Uri.EscapeUriString(emailSubject);
            emailBody = System.Uri.EscapeUriString(emailBody);
            Application.OpenURL("mailto:" + emailAddress + "?subject=" + emailSubject + "&body=" + emailBody);
        }
	    public void MoreGames()
	    {
	    	Application.OpenURL("https://play.google.com/store/apps/developer?id=Open+World+Games");
	    }

        //===============================================================================================    

        public void CustomiseTruckPressed()
        {
            foreach (GameObject panel in uiGameObjects.envPlayLevelsPanels)
            {
                panel.SetActive(false);
            }

            uiGameObjects.CustomisationPanel.SetActive(true);
            uiGameObjects.HomePanel.SetActive(false);
            uiGameObjects.CoinsAtTheTopPanel.SetActive(true);
            uiGameObjects.garagePlace.SetActive(true);
            uiGameObjects.uiCamera.SetActive(false);
            uiGameObjects.levelDescriptionPanel.SetActive(false);
        }
        public void finishedCustomisationPressed()
        {
            uiGameObjects.CustomisationPanel.SetActive(false);
            uiGameObjects.envPlayLevelsPanels[GameData.GetSelectedEnv()].SetActive(true);
            uiGameObjects.levelDescriptionPanel.SetActive(true);
            uiGameObjects.truckInGarage.SetActive(false);

        }
        //==================================================

        public void SelectUpgradableItem(int itemIndex)
        {

            foreach (GameObject upGradableItem in uiGameObjects.upGradableItems)
            {
                upGradableItem.SetActive(false);
            }

            uiGameObjects.upGradableItems[itemIndex].SetActive(true);


        }


        //=============================================================================================
        public void EnvironmentPressed(int environmentIndex)
        {

            GameData.SetSelectedEnv(environmentIndex);

            foreach (GameObject environmentImage in uiGameObjects.environmentImages)
            {
                environmentImage.SetActive(false);
            }
            uiGameObjects.environmentImages[environmentIndex].SetActive(true);


        }


        public void NextPressed()
        {
            uiGameObjects.HomePanel.SetActive(false);
            uiGameObjects.CoinsAtTheTopPanel.SetActive(false);
            uiGameObjects.envPlayLevelsPanels[GameData.GetSelectedEnv()].SetActive(true);
            uiGameObjects.levelDescriptionPanel.SetActive(true);



        }
        //===============================================================================================
        public void BackPlayLevelsPressed()
        {
            uiGameObjects.HomePanel.SetActive(true);
            foreach (GameObject panel in uiGameObjects.envPlayLevelsPanels)
            {
                panel.SetActive(false);
            }
            uiGameObjects.levelDescriptionPanel.SetActive(false);
            uiGameObjects.CoinsAtTheTopPanel.SetActive(true);

            // So you can add your Instertitial Ad method here.

        }

        public void backToEntryPanel()
        {
            uiGameObjects.HomePanel.SetActive(false);
            uiGameObjects.CoinsAtTheTopPanel.SetActive(false);
            uiGameObjects.EntryPanel.SetActive(true);
        }

        public void ShopPressed()
        {
            uiGameObjects.ShopPanel.SetActive(true);

        }
        public void BackShopPressed()
        {
            uiGameObjects.ShopPanel.SetActive(false);
            specsPanel.SetActive(true);
        }

        public void FreeCoinsPressed()
        {
            uiGameObjects.FreeCoinsPanel.SetActive(true);

        }
        public void CancelFreeCoinspanel()
        {
            uiGameObjects.FreeCoinsPanel.SetActive(false);
        }

        public void NotEnoughCoinsOkPressed()
        {
            uiGameObjects.notEnoughCoinsNotification.SetActive(false);
            
        }

        public void NotEnoughCoinsShopPressed()
        {
            uiGameObjects.notEnoughCoinsNotification.SetActive(false);
            uiGameObjects.ShopPanel.SetActive(true);
            specsPanel = GameObject.Find("Truck" + GameData.GetSelectedTruck() + "(Clone)/CanvasTruckSpecs");
            specsPanel.SetActive(false);
        }


    }

}

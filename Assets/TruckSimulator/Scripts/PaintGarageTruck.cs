using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TruckSimulatorTemplate;


/// <summary>
/// This script paints the garageTruck body when the paint buttons are pressed.
/// Location: HomeScene "CanvasPanels__.sc>>/EnvironmentPanel0__.sc || EnvironmentPanel1__.sc || EnvironmentPanel2__.sc || EnvironmentPanel3__.sc || EnvironmentPanel4__.sc"
/// </summary>


namespace TruckSimulatorTemplate
{
    public class PaintGarageTruck : MonoBehaviour
    {
        public UiGameObjects uiGameObjects;
        int paintIndex;
        public TruckPaints truckPaint;
        [HideInInspector]
        public MeshRenderer meshRendererBody;
        InstantiateGarageTrucks instantiateGarageTrucks;
        DisablePaintPadlocks disablePaintPadlocks;
        TruckProperties trucksProperties;

        void Start()
        {

            instantiateGarageTrucks = GetComponent<InstantiateGarageTrucks>();
            trucksProperties = GameObject.Find("PlayerTrucksProperties__.sc").GetComponent<TruckProperties>();
            disablePaintPadlocks = GetComponent<DisablePaintPadlocks>();


        }
        public void FindAndAssignMeshrenderer()
        {
            meshRendererBody = instantiateGarageTrucks.truckInGarage.transform.Find("body").GetComponent<MeshRenderer>();
            meshRendererBody.material = truckPaint.paint[trucksProperties.playerTruckProperties[GameData.GetSelectedTruck()].paintId].paintMaterial;

        }

        public void SelectPaintMaterial(int paintIndex)
        {
            this.paintIndex = paintIndex;
            meshRendererBody.material = truckPaint.paint[paintIndex].paintMaterial;

            if (!disablePaintPadlocks.paintPadlocks[paintIndex].activeSelf)
            {
                trucksProperties.playerTruckProperties[GameData.GetSelectedTruck()].paintId = paintIndex;
                trucksProperties.UpdateProperties();
            }

        }

        public void BuyPaint()
        {
            int coinsAmountLeft;
            if (GameData.GetCoinsAmount() >= truckPaint.paint[paintIndex].paintPrice)
            {
                coinsAmountLeft = GameData.GetCoinsAmount() - truckPaint.paint[paintIndex].paintPrice;
                uiGameObjects.coinsText.text = coinsAmountLeft.ToString();
                GameData.SetCoinsAmount(coinsAmountLeft);
                disablePaintPadlocks.paintPadlocks[paintIndex].SetActive(false);
                trucksProperties.playerTruckProperties[GameData.GetSelectedTruck()].paintId = paintIndex;
                trucksProperties.UpdateProperties();
                GameData.SetPaintPadlockStatus(paintIndex, "yes");
            }

            else
            {
                uiGameObjects.notEnoughCoinsNotification.SetActive(true);
            }

        }
    }

}

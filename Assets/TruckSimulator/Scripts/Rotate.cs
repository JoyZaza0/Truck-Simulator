using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script rotates the image.
/// Location: HomeScene "CanvasPanel__.sc>>/FRESHGAMEPANEL__.sc>>/Intro1__.sc/loadingImage.
/// </summary>
 
namespace TruckSimulatorTemplate
{
    public class Rotate : MonoBehaviour
    {

        void Update()
        {
            transform.Rotate(0, 0, -200 * Time.deltaTime);
        }
    }

}

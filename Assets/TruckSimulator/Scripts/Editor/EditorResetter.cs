using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TruckSimulatorTemplate;
using System;


namespace TruckSimulatorTemplate
{
    [CustomEditor(typeof(Resetter))]

    public class EditorResetter : Editor
    {
        Resetter resetter;
       
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            resetter = (Resetter)target;

            EditorGUILayout.Space();
            GUI.color = Color.red;

            if (GUILayout.Button("RESET ENTIRE GAME!"))
            {
             
               PlayerPrefs.DeleteAll();
                  
            }
            
            EditorGUILayout.Space();
            GUI.color = Color.yellow;

            if (GUILayout.Button("Give Coins 1,000,000"))
            {

                GameData.SetCoinsAmount(10000);

            }
            EditorGUILayout.Space();


            if (GUILayout.Button("Reset Coins to 0"))
            {
                GameData.SetCoinsAmount(0);
            }
 

        }

    }

}

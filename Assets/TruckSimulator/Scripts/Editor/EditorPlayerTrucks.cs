using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TruckSimulatorTemplate;

namespace TruckSimulatorTemplate
{
    [CustomEditor(typeof(PlayerTrucks))]

    public class EditorPlayerTrucks : Editor
    {
        PlayerTrucks prop;

        Vector2 scrollPos;
        List<PlayerTrucks.Trucks> playerTruckss = new List<PlayerTrucks.Trucks>();

        Color orgColor;



        public override void OnInspectorGUI()
        {

            serializedObject.Update();
            prop = (PlayerTrucks)target;
            orgColor = GUI.color;

            EditorGUILayout.Space();
            GUI.color = Color.green;
            EditorGUILayout.LabelField("---Add Player Trucks in your preferred Order here---", EditorStyles.boldLabel);

            EditorGUILayout.Space();
            GUI.color = Color.cyan;
            if (GUILayout.Button("Locate Player Trucks folder in Project tab"))
            {

                Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/TruckSimulator/Prefabs/PlayerTrucks");

            }

            EditorGUILayout.Space();
            GUI.color = Color.white;
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

            EditorGUIUtility.labelWidth = 110f;


            for (int i = 0; i < prop.playerTrucks.Length; i++)
            {
                GUI.color = Color.cyan;

                EditorGUILayout.BeginVertical(GUI.skin.box);
                GUI.color = Color.white;
                EditorGUILayout.Space();

                if (prop.playerTrucks[i].playerTruck)
                    EditorGUILayout.LabelField(prop.playerTrucks[i].playerTruck.name, EditorStyles.boldLabel);


                prop.playerTrucks[i].playerTruck = (GameObject)EditorGUILayout.ObjectField("Truck", prop.playerTrucks[i].playerTruck, typeof(GameObject), false);


                EditorGUILayout.Space();
                EditorGUILayout.BeginHorizontal();

                GUI.color = Color.red;
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Remove", GUILayout.Width(100), GUILayout.Height(20)))
                { RemovePlayertruck(i); }
                GUI.color = orgColor;

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space();
                EditorGUILayout.EndVertical();

            }
            EditorGUILayout.Space();

            GUI.color = Color.cyan;

            if (GUILayout.Button("Add Player Truck"))
            {

                AddPlayertruck();

            }



            GUI.color = orgColor;

            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("--STEGames by Kallai Stephen--", EditorStyles.centeredGreyMiniLabel, GUILayout.MaxHeight(50f));

            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
                EditorUtility.SetDirty(prop);

        }

        void AddPlayertruck()
        {

            playerTruckss.Clear();
            playerTruckss.AddRange(prop.playerTrucks);
            PlayerTrucks.Trucks newCar = new PlayerTrucks.Trucks();
            playerTruckss.Add(newCar);
            prop.playerTrucks = playerTruckss.ToArray();

        }

        void RemovePlayertruck(int index)
        {

            playerTruckss.Clear();
            playerTruckss.AddRange(prop.playerTrucks);
            playerTruckss.RemoveAt(index);
            prop.playerTrucks = playerTruckss.ToArray();

        }
 
    }

}

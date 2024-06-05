using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TruckSimulatorTemplate;

namespace TruckSimulatorTemplate
{
    [CustomEditor(typeof(GarageTrucks))]

    public class EditorGarageTrucks : Editor
    {
        GarageTrucks prop;

        Vector2 scrollPos;
        List<GarageTrucks.Trucks> GarageTruckss = new List<GarageTrucks.Trucks>();

        Color orgColor;


        public override void OnInspectorGUI()
        {

            serializedObject.Update();
            prop = (GarageTrucks)target;
            orgColor = GUI.color;

            EditorGUILayout.Space();
            GUI.color = Color.green;
            EditorGUILayout.LabelField("-Add Your Garage Trucks in Your Preferred Order Here-", EditorStyles.boldLabel);

            EditorGUILayout.Space();
            GUI.color = Color.cyan;
            if (GUILayout.Button("Locate Garage Trucks folder in Project tab"))
            {

                Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/TruckSimulator/Prefabs/GarageTrucks");

            }

            EditorGUILayout.Space();
            GUI.color = Color.white;
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

            EditorGUIUtility.labelWidth = 110f;

            GUILayout.Label("Player Trucks", EditorStyles.boldLabel);

            for (int i = 0; i < prop.garageTrucks.Length; i++)
            {
                GUI.color = Color.yellow;

                EditorGUILayout.BeginVertical(GUI.skin.box);
                GUI.color = Color.white;
                EditorGUILayout.Space();

                if (prop.garageTrucks[i].garageTruck)
                    EditorGUILayout.LabelField(prop.garageTrucks[i].garageTruck.name, EditorStyles.boldLabel);


                prop.garageTrucks[i].garageTruck = (GameObject)EditorGUILayout.ObjectField("Truck", prop.garageTrucks[i].garageTruck, typeof(GameObject), false);


                EditorGUILayout.Space();
                EditorGUILayout.BeginHorizontal();

                GUI.color = Color.red;
                if (GUILayout.Button("Remove")) { RemoveGaragetruck(i); }
                GUI.color = orgColor;

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space();
                EditorGUILayout.EndVertical();

            }

            GUI.color = Color.cyan;

            if (GUILayout.Button("Add Garage Truck"))
            {

                AddGaragetruck();

            }
            

            GUI.color = orgColor;

            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("--STEGames by Kallai Stephen--", EditorStyles.centeredGreyMiniLabel, GUILayout.MaxHeight(50f));

            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
                EditorUtility.SetDirty(prop);

        }

        void AddGaragetruck()
        {

            GarageTruckss.Clear();
            GarageTruckss.AddRange(prop.garageTrucks);
            GarageTrucks.Trucks newCar = new GarageTrucks.Trucks();
            GarageTruckss.Add(newCar);
            prop.garageTrucks = GarageTruckss.ToArray();

        }

        void RemoveGaragetruck(int index)
        {

            GarageTruckss.Clear();
            GarageTruckss.AddRange(prop.garageTrucks);
            GarageTruckss.RemoveAt(index);
            prop.garageTrucks = GarageTruckss.ToArray();

        }
 

    }

}

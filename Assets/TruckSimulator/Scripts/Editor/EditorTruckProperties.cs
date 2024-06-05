using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TruckSimulatorTemplate;

namespace TruckSimulatorTemplate
{
    [CustomEditor(typeof(TruckProperties))]

    public class EditorTruckProperties : Editor
    {
        TruckProperties prop;
        private SerializedProperty levels;
        Vector2 scrollPos;
        List<TruckProperties.PlayerTruckProperties> TruckPropertiess = new List<TruckProperties.PlayerTruckProperties>();
        float colorIncrease;
        Color orgColor;
        float increses = 0.3f;
        Color newColor = new Vector4(0.3f, 0.4f, 0.6f);


        private SerializedProperty spriteProperty;
        //  GUI.color = Color.cyan;
        private void OnEnable()
        {
            // Initialize the serialized property for your sprite field
            levels = serializedObject.FindProperty("playerTruckProperties");


        }

        public override void OnInspectorGUI()
        {
            GUI.color = Color.magenta;
            serializedObject.Update();
            prop = (TruckProperties)target;
            orgColor = GUI.color;

            EditorGUILayout.Space();
            GUI.color = Color.yellow;
            EditorGUILayout.LabelField("--These are only READONLY. In playmode, the fields are filled--", EditorStyles.boldLabel);
            GUI.color = Color.white;
            EditorGUILayout.Space();             
            EditorGUILayout.Space();
            GUI.color = Color.green;
            EditorGUILayout.LabelField("Increase the size according to the number of your playerTrucks.", EditorStyles.boldLabel);            
            EditorGUILayout.Space();             
            EditorGUILayout.Space();

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

            GUI.color = Color.yellow;
            EditorGUIUtility.labelWidth = 110f;
            //EditorGUIUtility.fieldWidth = 10f;

            
            GUI.color = Color.cyan;
            levels.arraySize = EditorGUILayout.IntField("Size of Trucks:", levels.arraySize);

            for (int i = 0; i < levels.arraySize; i++)
            {
                GUI.color = Color.blue;
                EditorGUILayout.BeginVertical(GUI.skin.box);
                GUI.color = Color.white;
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                GUILayout.FlexibleSpace();

                var lev = levels.GetArrayElementAtIndex(i);
                
                EditorGUILayout.PropertyField(lev, new GUIContent("playerTruck " + i + " properties"), true, GUILayout.ExpandWidth(true));
                GUI.color = Color.cyan;
                EditorGUILayout.BeginHorizontal();
                
                GUI.color = Color.red;
                EditorGUILayout.EndHorizontal();
                

                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.Space();
            GUI.color = Color.cyan;
           

            EditorGUILayout.EndScrollView();

            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
                EditorUtility.SetDirty(prop);

        }

       

         

    }

}


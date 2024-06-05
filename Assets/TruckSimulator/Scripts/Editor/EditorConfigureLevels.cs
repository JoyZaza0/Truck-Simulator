using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TruckSimulatorTemplate;

namespace TruckSimulatorTemplate
{
    [CustomEditor(typeof(ConfigureLevels))]

    public class EditorConfigureLevels : Editor
    {
        ConfigureLevels prop;
        private SerializedProperty levels;
        Vector2 scrollPos;
        List<ConfigureLevels.ConfigureLevelsElements> ConfigureLevelss = new List<ConfigureLevels.ConfigureLevelsElements>();
        float colorIncrease;
        Color orgColor;
        float increses = 0.3f;
        Color newColor = new Vector4(0.3f, 0.4f, 0.6f);


        private SerializedProperty spriteProperty;
        //  GUI.color = Color.cyan;
        private void OnEnable()
        {
            // Initialize the serialized property for your sprite field
            levels = serializedObject.FindProperty("configureLevelsElements");


        }

        public override void OnInspectorGUI()
        {
            GUI.color = Color.magenta;
            serializedObject.Update();
            prop = (ConfigureLevels)target;
            orgColor = GUI.color;

            EditorGUILayout.Space();
            GUI.color = Color.yellow;
            EditorGUILayout.LabelField("         ----------ConfigureLevels Editor----------", EditorStyles.boldLabel);
            GUI.color = Color.white;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Edit individual level configuration here", EditorStyles.helpBox);
            EditorGUILayout.Space();

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);


            EditorGUIUtility.labelWidth = 110f;
            //EditorGUIUtility.fieldWidth = 10f;

            GUILayout.Label("Player ConfigureLevels", EditorStyles.boldLabel);
            GUI.color = Color.cyan;
            levels.arraySize = EditorGUILayout.IntField("Size of Levels:", levels.arraySize);

            for (int i = 0; i < levels.arraySize; i++)
            {
                GUI.color = Color.yellow;
                EditorGUILayout.BeginVertical(GUI.skin.box);
                GUI.color = Color.white;
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                GUILayout.FlexibleSpace();

                var lev = levels.GetArrayElementAtIndex(i);

                EditorGUILayout.PropertyField(lev, new GUIContent("Level " + i), true, GUILayout.ExpandWidth(true));
                GUI.color = Color.cyan;
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("Trucks Index"))
                {
                    Selection.activeObject = PlayerTrucks.Instance;
                }
                if (GUILayout.Button("EnvTracks Index"))
                {
                    Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/Resources/EnvTracks");
                }
                GUI.color = Color.red;
                EditorGUILayout.EndHorizontal();
                if (GUILayout.Button("Remove"))
                {
                    RemoveSunshade(i);
                }

                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.Space();
            GUI.color = Color.cyan;
            if (GUILayout.Button("Add"))
            {
                AddNewUpgradable();
            }

            EditorGUILayout.EndScrollView();

            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
                EditorUtility.SetDirty(prop);

        }

        void AddNewUpgradable()
        {

            ConfigureLevelss.Clear();
            ConfigureLevelss.AddRange(prop.configureLevelsElements);
            ConfigureLevels.ConfigureLevelsElements newCar = new ConfigureLevels.ConfigureLevelsElements();
            ConfigureLevelss.Add(newCar);
            prop.configureLevelsElements = ConfigureLevelss.ToArray();

        }

        void RemoveSunshade(int index)
        {

            ConfigureLevelss.Clear();
            ConfigureLevelss.AddRange(prop.configureLevelsElements);
            ConfigureLevelss.RemoveAt(index);
            prop.configureLevelsElements = ConfigureLevelss.ToArray();

        }

         

    }

}


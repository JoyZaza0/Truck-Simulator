using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TruckSimulatorTemplate;

namespace TruckSimulatorTemplate
{
    [CustomEditor(typeof(EnvironmentTracks))]

    public class EditorEnvTracks : Editor
    {

        EnvironmentTracks prop;

        Vector2 scrollPos;
        List<EnvironmentTracks.EnvTracks> EnvironmentTrackss = new List<EnvironmentTracks.EnvTracks>();

        Color orgColor;

        [MenuItem("Window/Truck Simulator Template/Locate Environment Tracks folder", false, 101)]
        public static void OpenEnvironmentTracksFolder()
        {
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/TruckSimulator/Resources/EnvTracks");
        }

        public override void OnInspectorGUI()
        {

            serializedObject.Update();
            prop = (EnvironmentTracks)target;
            orgColor = GUI.color;
            EditorGUILayout.Space();
            GUI.color = Color.green;
            EditorGUILayout.LabelField("-Add Your EnvTracks in Your Preferred Order Here-", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            GUI.color = Color.red;

            EditorGUILayout.LabelField("Please put appropriate tracks here. If this scriptable \n object is  named 'Env0Tracks', then make sure \n only enviroment 0 individual tracks go here.", EditorStyles.boldLabel, GUILayout.Height(50));


            EditorGUILayout.Space();

            GUI.color = Color.cyan;
            if (GUILayout.Button("Locate Env Tracks folder in Project tab"))
            {

                Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/TruckSimulator/Resources/EnvTracks");

            }

            EditorGUILayout.Space();
            GUI.color = Color.white;

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

            EditorGUIUtility.labelWidth = 110f;



            for (int i = 0; i < prop.envTracks.Length; i++)
            {
                GUI.color = Color.blue;

                EditorGUILayout.BeginVertical(GUI.skin.box);
                GUI.color = Color.white;
                EditorGUILayout.Space();

                if (prop.envTracks[i].track)
                    EditorGUILayout.LabelField(prop.envTracks[i].track.name, EditorStyles.boldLabel);


                prop.envTracks[i].track = (GameObject)EditorGUILayout.ObjectField("Environment Track", prop.envTracks[i].track, typeof(GameObject), false);


                EditorGUILayout.Space();
                EditorGUILayout.BeginHorizontal();

                GUI.color = Color.red;
                if (GUILayout.Button("Remove")) { RemoveTrack(i); }
                GUI.color = orgColor;

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space();
                EditorGUILayout.EndVertical();

            }

            GUI.color = Color.cyan;
            EditorGUILayout.Space();
            if (GUILayout.Button("Create Env Track"))
            {

                AddEnvtrack();

            }

            GUI.color = orgColor;

            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("--STEGames by Kallai Stephen--", EditorStyles.centeredGreyMiniLabel, GUILayout.MaxHeight(50f));

            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
                EditorUtility.SetDirty(prop);

        }

        void AddEnvtrack()
        {

            EnvironmentTrackss.Clear();
            EnvironmentTrackss.AddRange(prop.envTracks);
            EnvironmentTracks.EnvTracks newCar = new EnvironmentTracks.EnvTracks();
            EnvironmentTrackss.Add(newCar);
            prop.envTracks = EnvironmentTrackss.ToArray();

        }

        void RemoveTrack(int index)
        {

            EnvironmentTrackss.Clear();
            EnvironmentTrackss.AddRange(prop.envTracks);
            EnvironmentTrackss.RemoveAt(index);
            prop.envTracks = EnvironmentTrackss.ToArray();

        }
 


    }

}

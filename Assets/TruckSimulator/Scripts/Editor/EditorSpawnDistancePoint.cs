using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TruckSimulatorTemplate;

namespace TruckSimulatorTemplate
{

    [CustomEditor(typeof(DistancePointSpawner))]
    public class EditorSpawnDistancePoint : Editor
    {

        DistancePointSpawner distancePointInstant;
        bool canDo = false;
        GameObject distancePoint;
        public override void OnInspectorGUI()
        {
            GUI.color = Color.green;
            EditorGUILayout.LabelField("1. Click the 'START PLACEMENT' button", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("2. Click spots on env track to add distancePoints", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("3. Click 'END PLACEMENT' button when finished", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            GUI.color = Color.red;
            EditorGUILayout.LabelField("4. Make sure the 'Number Of Distance Points' below matches the\n", EditorStyles.boldLabel);
            EditorGUILayout.LabelField(" actual number in the hierarchy. If not, delete ", EditorStyles.boldLabel);
            EditorGUILayout.LabelField(" some manually to ensure that. ", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            GUI.color = Color.white;
            base.OnInspectorGUI();
            distancePointInstant = (DistancePointSpawner)target;
            EditorGUILayout.Space();

            GUI.color = Color.green;
            if (GUILayout.Button("START PLACEMENT"))
            {
                ActiveEditorTracker.sharedTracker.isLocked = true;
                canDo = true;
            }
            EditorGUILayout.Space();
            GUI.color = Color.yellow;
            if (GUILayout.Button("END PLACEMENT"))
            {
                ActiveEditorTracker.sharedTracker.isLocked = false;
                canDo = false;
            }

        }

        void Start()
        {

        }


        void OnSceneGUI()
        {
            if (canDo)
            {
                Event currentEvent = Event.current;

                if (currentEvent.type == EventType.MouseDown && currentEvent.button == 0)
                {

                    Ray ray = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {


                        distancePoint = Instantiate(distancePointInstant.prefab, hit.point, Quaternion.identity);
                        distancePoint.transform.parent = distancePointInstant.transform;
                        distancePointInstant.NumberOfDistancePoints++;
                    }
                }
            }

        }
    }

}


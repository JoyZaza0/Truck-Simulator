using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TruckSimulatorTemplate;


namespace TruckSimulatorTemplate
{
    [CustomEditor(typeof(TruckPaints))]
    public class EditorTruckPaints : Editor
    {
        TruckPaints prop;

        Vector2 scrollPos;
        List<TruckPaints.Paint> TruckPaintss = new List<TruckPaints.Paint>();

        Color orgColor;

        public override void OnInspectorGUI()
        {

            serializedObject.Update();
            prop = (TruckPaints)target;
            orgColor = GUI.color;

            EditorGUILayout.Space();
            GUI.color = Color.green;
            EditorGUILayout.LabelField("-Add Your Paint Materials in Your Preferred Order Here-", EditorStyles.boldLabel);


            EditorGUILayout.Space();
            GUI.color = Color.cyan;
            if (GUILayout.Button("Locate Truck Paints folder in Project tab"))
            {

                Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/TruckSimulator/Materials/PaintMaterials");

            }

            EditorGUILayout.Space();
            GUI.color = Color.white;
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

            EditorGUIUtility.labelWidth = 110f;


            for (int i = 0; i < prop.paint.Length; i++)
            {
                GUI.color = Color.blue;

                EditorGUILayout.BeginVertical(GUI.skin.box);
                GUI.color = Color.white;
                EditorGUILayout.Space();


                if (prop.paint[i].paintMaterial)
                    EditorGUILayout.LabelField(prop.paint[i].paintMaterial.name, EditorStyles.boldLabel);


                prop.paint[i].paintMaterial = (Material)EditorGUILayout.ObjectField("Paint", prop.paint[i].paintMaterial, typeof(Material), false);



                EditorGUILayout.Space();
                EditorGUILayout.BeginHorizontal();

                prop.paint[i].paintPrice = EditorGUILayout.IntField("Price", prop.paint[i].paintPrice, GUILayout.Width(150f));

                GUI.color = Color.red;
                if (GUILayout.Button("Remove")) { RemovePaintMat(i); }
                GUI.color = orgColor;

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space();
                EditorGUILayout.EndVertical();

            }
            EditorGUILayout.Space();
            GUI.color = Color.cyan;

            if (GUILayout.Button("Add Truck Paint Material"))
            {

                AddPaintMat();

            }


            GUI.color = orgColor;

            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("--STEGames by Kallai Stephen--", EditorStyles.centeredGreyMiniLabel, GUILayout.MaxHeight(50f));

            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
                EditorUtility.SetDirty(prop);

        }

        void AddPaintMat()
        {

            TruckPaintss.Clear();
            TruckPaintss.AddRange(prop.paint);
            TruckPaints.Paint newCar = new TruckPaints.Paint();
            TruckPaintss.Add(newCar);
            prop.paint = TruckPaintss.ToArray();

        }

        void RemovePaintMat(int index)
        {

            TruckPaintss.Clear();
            TruckPaintss.AddRange(prop.paint);
            TruckPaintss.RemoveAt(index);
            prop.paint = TruckPaintss.ToArray();

        }
 
    }

}

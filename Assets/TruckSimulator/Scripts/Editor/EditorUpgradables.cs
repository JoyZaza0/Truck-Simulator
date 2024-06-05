using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TruckSimulatorTemplate;

namespace TruckSimulatorTemplate
{
    [CustomEditor(typeof(Upgradables))]
    public class EditorUpgradables : Editor
    {
        Upgradables prop;

        Vector2 scrollPos;
        List<Upgradables.Upgradable> Upgradabless = new List<Upgradables.Upgradable>();

        Color orgColor;




        public override void OnInspectorGUI()
        {

            serializedObject.Update();
            prop = (Upgradables)target;
            orgColor = GUI.color;

            EditorGUILayout.Space();

            GUI.color = Color.green;

            EditorGUILayout.LabelField("-Add Your Paint Materials in Your Preferred Order Here-", EditorStyles.boldLabel);

            EditorGUILayout.Space();
            GUI.color = Color.cyan;
            if (GUILayout.Button("Locate Upgradables folder in Project tab"))
            {

                Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/TruckSimulator/Prefabs/Upgradables");

            }

            EditorGUILayout.Space();
            GUI.color = Color.white;

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

            EditorGUIUtility.labelWidth = 110f;
            //EditorGUIUtility.fieldWidth = 10f;


            for (int i = 0; i < prop.upgradable.Length; i++)
            {

                GUI.color = Color.magenta;

                EditorGUILayout.BeginVertical(GUI.skin.box);
                GUI.color = Color.white;
                EditorGUILayout.Space();
                
                if (prop.upgradable[i].sunshade)
                GUI.color = Color.yellow;
                    EditorGUILayout.LabelField("Upgradable Slot " + (i + 1), EditorStyles.boldLabel);

                EditorGUILayout.Space();
                GUI.color = Color.white;
                
                prop.upgradable[i].sunshade = (GameObject)EditorGUILayout.ObjectField("Sun shade", prop.upgradable[i].sunshade, typeof(GameObject), false);
                prop.upgradable[i].priceOfSunshade = EditorGUILayout.IntField("Price", prop.upgradable[i].priceOfSunshade, GUILayout.Width(150f));
                EditorGUILayout.Space();

                prop.upgradable[i].bullbar = (GameObject)EditorGUILayout.ObjectField("Bullbar", prop.upgradable[i].bullbar, typeof(GameObject), false);
                prop.upgradable[i].priceOfbullbar = EditorGUILayout.IntField("Price", prop.upgradable[i].priceOfbullbar, GUILayout.Width(150f));
                EditorGUILayout.Space();

                prop.upgradable[i].topbar = (GameObject)EditorGUILayout.ObjectField("Topbar", prop.upgradable[i].topbar, typeof(GameObject), false);
                prop.upgradable[i].priceOftopbar = EditorGUILayout.IntField("Price", prop.upgradable[i].priceOftopbar, GUILayout.Width(150f));
                EditorGUILayout.Space();

                prop.upgradable[i].lowbar = (GameObject)EditorGUILayout.ObjectField("Lowbar", prop.upgradable[i].lowbar, typeof(GameObject), false);
                prop.upgradable[i].priceOflowbar = EditorGUILayout.IntField("Price", prop.upgradable[i].priceOflowbar, GUILayout.Width(150f));
                EditorGUILayout.Space();

                prop.upgradable[i].other = (GameObject)EditorGUILayout.ObjectField("Other", prop.upgradable[i].other, typeof(GameObject), false);
                prop.upgradable[i].priceOfother = EditorGUILayout.IntField("Price", prop.upgradable[i].priceOfother, GUILayout.Width(150f));



                EditorGUILayout.Space();
                EditorGUILayout.BeginHorizontal();



                GUI.color = Color.red;
                
                GUI.color = orgColor;

                EditorGUILayout.EndHorizontal();

                EditorGUILayout.Space();
                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();

            }

            GUI.color = Color.cyan;
            EditorGUILayout.Space();
        

            GUI.color = orgColor;

            EditorGUILayout.EndScrollView();

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("by Kallai Stephen -- STEGames", EditorStyles.centeredGreyMiniLabel, GUILayout.MaxHeight(50f));

            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
                EditorUtility.SetDirty(prop);

        }

        
 
    }

}

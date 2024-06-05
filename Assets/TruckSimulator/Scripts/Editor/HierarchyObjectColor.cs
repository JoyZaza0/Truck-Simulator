using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace TruckSimulatorTemplate
{
#if UNITY_EDITOR
    using UnityEditor;



    /// <summary> Sets a background color for game objects in the Hierarchy tab</summary>
    [UnityEditor.InitializeOnLoad]
#endif
    public class HierarchyObjectColor
    {
        private static Vector2 offset = new Vector2(20, 1);

        static HierarchyObjectColor()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
        }

        private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {

            var obj = EditorUtility.InstanceIDToObject(instanceID);
            if (obj != null)
            {
                Color backgroundColor = Color.white;
                Color textColor = Color.white;
                Texture2D texture = null;

                // Write your object name in the hierarchy.

                if (obj.name == "GameObjects with scripts end in '__.sc'")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.0f, 0.9f, 0.0f);
                }
                if (obj.name == "GameObjects with child scripts end in '__.sc>>'")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.9f, 0.9f, 0.0f);
                }
                if (obj.name == "FRESHGAME__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.9f, 0.5f, 0.0f);
                }

                if (obj.name == "LEVELS__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.0f, 0.9f, 0.9f);
                }
                if (obj.name == "CUSTOMISETRUCK__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.9f, 0.5f, 0.0f);
                }
                if (obj.name == "UI_GAMEOBJECTS__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.0f, 0.9f, 0.9f);
                }
                if (obj.name == "UI_NAVIGATION__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.9f, 0.5f, 0.0f);
                }
                if (obj.name == "COINS__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.0f, 0.9f, 0.9f);
                }
                if (obj.name == "RESETTER__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.9f, 0.5f, 0.0f);
                }
                if (obj.name == "SHOP__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.0f, 0.9f, 0.9f);
                }
                if (obj.name == "SETTINGS__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.9f, 0.5f, 0.0f);
                }
                if (obj.name == "PlayerTrucksProperties__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.1f, 0.5f, 0.0f);
                }
                if (obj.name == "CanvasPanels__.sc>>")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.7f, 0.9f, 0.6f);
                }
                 if (obj.name == "INSTANTIATORS__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.7f, 0.9f, 0.6f);
                }
                if (obj.name == "STARTER__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.7f, 0.9f, 0.6f);
                }
                if (obj.name == "GAMEOVER__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.7f, 0.9f, 0.6f);
                }
                if (obj.name == "SCORER__.sc")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.7f, 0.9f, 0.6f);
                }


                if (obj.name == "---------------------------------------------------------------------------")
                {
                    backgroundColor = new Color(0.25f, 0.25f, 0.25f);
                    textColor = new Color(0.0f, 0.5f, 0.5f);
                }


                // Or you can use switch case
                //switch (obj.name)
                //{
                //    case "Main Camera":
                //        backgroundColor = Color.red;
                //        textColor = new Color(0.9f, 0.9f, 0.9f);
                //        break;
                //}


                if (backgroundColor != Color.white)
                {
                    Rect offsetRect = new Rect(selectionRect.position + offset, selectionRect.size);
                    Rect bgRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width + 50, selectionRect.height);

                    EditorGUI.DrawRect(bgRect, backgroundColor);
                    EditorGUI.LabelField(offsetRect, obj.name, new GUIStyle()
                    {
                        normal = new GUIStyleState() { textColor = textColor },
                        fontStyle = FontStyle.Bold
                    }
                    );

                    if (texture != null)
                        EditorGUI.DrawPreviewTexture(new Rect(selectionRect.position, new Vector2(selectionRect.height, selectionRect.height)), texture);
                }
            }
        }
    }
}


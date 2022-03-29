using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    Planet planet;
    Editor shapeEditor;
    Editor colorEditor;

    private void OnEnable()
    {
        planet = (Planet)target; 
    }

    public override void OnInspectorGUI()
    {
       

        using (var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed)
            {
                if (planet.autoUpdate)
                {
                    planet.GeneratePlanet();
                }
            }
        }


        if (GUILayout.Button("GENERATE PLANET"))
        {
            planet.GeneratePlanet();
        }

        ShowCustomEditor(planet.shapeSettings, ref shapeEditor, planet.OnShapeSettingsUpdated);
        ShowCustomEditor(planet.colorSettings, ref colorEditor, planet.OnColorSettingsUpdated);
    }

    void ShowCustomEditor(Object settings, ref Editor editor, System.Action onSettingsUpdated)
    {
        if(settings == null)
        {
            return; 
        }
        EditorGUILayout.InspectorTitlebar(true, settings);
        using(var check = new EditorGUI.ChangeCheckScope())
        {
            CreateCachedEditor(settings, null, ref editor);
            editor.OnInspectorGUI();
            if (check.changed)
            {
                if (planet.autoUpdate)
                {
                    onSettingsUpdated?.Invoke();

                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointManagerWindow : EditorWindow
{
    [MenuItem("Waypoint/Waypoints Editor Tools")]

    public static void ShowWindow()
    {
        GetWindow<WaypointManagerWindow>("Waypoint/Waypoints Editor Tools");
    }
}

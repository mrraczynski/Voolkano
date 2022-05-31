using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AI;
using UnityEngine;

public class AddMaxSlope : MonoBehaviour
{
    [MenuItem("NavMesh/Build With Slope 90")]
    public static void BuildSlope90()
    {
        SerializedObject obj = new SerializedObject(NavMeshBuilder.navMeshSettingsObject);
        SerializedProperty prop = obj.FindProperty("m_BuildSettings.agentSlope");
        prop.floatValue = 90.0f;
        obj.ApplyModifiedProperties();
        NavMeshBuilder.BuildNavMesh();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GizmoEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        SceneView.RepaintAll();
    }
}

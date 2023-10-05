using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Rule))]
public class EnumEditor : Editor
{
    private SerializedObject test;
    private SerializedProperty m_bActive,m_type, m_cubeId, m_cubeNum, m_cubePosList, m_bRotate, 
        m_leftAngle, m_rightAngle, m_roateSpeed, m_dir, m_rotateType, m_targetAngle;
    void OnEnable()
    {
        test = new SerializedObject(target);
        m_bActive = test.FindProperty("Active");
        m_cubeId = test.FindProperty("CubeId");
        m_type = test.FindProperty("BarrageType");
        m_cubeNum = test.FindProperty("CubeNum");
        m_cubePosList = test.FindProperty("CubePosList");
        m_bRotate = test.FindProperty("bRotate");
        m_leftAngle = test.FindProperty("LeftAngle");
        m_rightAngle = test.FindProperty("RightAngle");
        m_roateSpeed = test.FindProperty("RotateSpeed");
        m_dir = test.FindProperty("Dir");
        m_rotateType = test.FindProperty("type");
        m_targetAngle = test.FindProperty("TargetAngle");
    }
    public override void OnInspectorGUI()
    {
        test.Update();
        EditorGUILayout.PropertyField(m_bActive);
        EditorGUILayout.PropertyField(m_cubeId);
        EditorGUILayout.PropertyField(m_type);
        if (m_type.enumValueIndex == 0)
        {
            EditorGUILayout.PropertyField(m_cubePosList, true);
        }
        else if (m_type.enumValueIndex == 1)
        {
            EditorGUILayout.PropertyField(m_cubeNum);
        }
        EditorGUILayout.PropertyField(m_bRotate);
        if (m_bRotate.boolValue == true)
        {
            EditorGUILayout.PropertyField(m_dir);
            EditorGUILayout.PropertyField(m_roateSpeed);
            EditorGUILayout.PropertyField(m_rotateType);

            if (m_rotateType.enumValueIndex == 0)
            {
                EditorGUILayout.PropertyField(m_leftAngle);
                EditorGUILayout.PropertyField(m_rightAngle);
            }
            else if(m_rotateType.enumValueIndex == 1)
            {
                EditorGUILayout.PropertyField(m_targetAngle);
            }
        }
        test.ApplyModifiedProperties();
    }
}

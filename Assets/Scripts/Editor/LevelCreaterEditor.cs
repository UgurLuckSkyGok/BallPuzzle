using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(LevelCreater))]
public class LevelCreaterEditor : Editor
{
	private List<SceneData> sceneDatas = new List<SceneData>();

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();


		LevelCreater script = (LevelCreater)target;
		int levelId = serializedObject.FindProperty("levelId").intValue;
		var sceneObjects = Resources.LoadAll<GameObject>("Prefabs");

		EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

		GUILayout.FlexibleSpace();

		GUILayout.Label("Create Scene Object");

		GUILayout.FlexibleSpace();


		foreach (var item in sceneObjects)
		{
			if (GUILayout.Button(item.name, GUILayout.Height(30), GUILayout.Width(100)))
			{
				Instantiate(item, script.transform);
			}
		}
		EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Save Data", GUILayout.Height(40), GUILayout.Width(100)))
		{
			script.SaveLevel();
			serializedObject.FindProperty("levelId").intValue = 0;
			AssetDatabase.Refresh();
			Repaint();

		}

		if (GUILayout.Button("Clear Objects", GUILayout.Height(40), GUILayout.Width(100)))
		{
			script.ClearObjects();
		}

		if (GUILayout.Button("Load Data", GUILayout.Height(40), GUILayout.Width(100)))
		{
			script.LoadLevel(levelId);

		}
		GUILayout.EndHorizontal();
		EditorGUILayout.Space();
		EditorGUILayout.Space();


		if (levelId == 0)
		{
			EditorGUILayout.HelpBox("levelId can not be 0", MessageType.Error, true);
		}

		serializedObject.ApplyModifiedProperties();
		serializedObject.Update();

	}
}

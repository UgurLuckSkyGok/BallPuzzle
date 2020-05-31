using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[InitializeOnLoad]
public class EditorManager
{

	static EditorManager()
	{
		EditorApplication.update += Update;
	}

	static void Update()
	{
		if (Input.GetKey(KeyCode.P))
		{
			Debug.Log("Pause");
			Debug.Break();

		}

		if (Input.GetKey(KeyCode.Keypad0))
		{
			Debug.Log("SlowTime");
			Time.timeScale = 0.1f;
		}

		if (Input.GetKey(KeyCode.Keypad1))
		{
			Debug.Log("NormalTime");
			Time.timeScale = 1f;
		}

	}

}

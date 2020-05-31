using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[CreateAssetMenu]
public class LevelScriptable : ScriptableObject
{
	[SerializeField] private TextAsset levelData;

	/// <summary>
	/// Json dosyasındaki obje bilgilerini döner
	/// </summary>
	/// <returns></returns>
	public SceneData[] GetLevelData()
	{
		SceneData[] sceneData = JsonHelper.FromJson<SceneData>(levelData.text);
		return sceneData;
	}
}

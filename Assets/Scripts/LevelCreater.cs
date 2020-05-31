using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using MyExtension;


public class LevelCreater : Singleton<LevelCreater>
{
	[Range(0, 5)]
	[SerializeField] private int levelId;

	private List<SceneData> sceneDatas = new List<SceneData>();


	/// <summary>
	/// Sahne datasını "Resources/LevelData" içerisine kaydeder
	/// </summary>
	public void SaveLevel()
	{
		sceneDatas.Clear();
		string dataPath = Path.Combine(Application.dataPath, "Resources/LevelData/" + levelId + ".json");

		var sceneObjects = FindObjectsOfType<SceneObject>();

		foreach (var item in sceneObjects)
		{
			sceneDatas.Add(item.GetSceneData());
		}

		string dataJson = JsonHelper.ToJson(sceneDatas.ToArray(), true);
		File.WriteAllText(dataPath, dataJson);
	}

	/// <summary>
	/// Kaydedilmiş sahne datasını yükler
	/// </summary>
	/// <param name="level"></param>
	public void LoadLevel(int level)
	{
		ClearObjects();
		TextAsset text = Resources.Load<TextAsset>(Path.Combine("LevelData", level.ToString()));
		SceneData[] characterInfos = JsonHelper.FromJson<SceneData>(text.text);
		GameObject sceneObject;
		foreach (SceneData data in characterInfos)
		{
			if (data.objectType == ObjectType.Player)
			{
				sceneObject = GameObject.FindGameObjectWithTag("Player"); //PlayerController.instance.gameObject;
			} 
			else
			{
				GameObject prefab = Resources.Load<GameObject>(Path.Combine("Prefabs", data.objectType.ToString()));
				sceneObject = Instantiate(prefab, transform);

			}

			sceneObject.GetComponent<SceneObject>().SetSceneData(data);

		}
	}

	/// <summary>
	/// Level Creater içerisindeki tüm objeleri siler
	/// </summary>
	public void ClearObjects()
	{
		transform.DestroyAllChild();
	}
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
	/// <summary>
	/// Level Scriptable içerisindeki data bilgisi ile sahneyi yükler
	/// </summary>
	/// <param name="level"></param>
	public void LoadLevel(int level)
	{
		LevelScriptable levelScriptable = Resources.Load<LevelScriptable>(Path.Combine("Levels", level.ToString()));
		SceneData[] sceneData = levelScriptable.GetLevelData();
		GameObject sceneObject;
		foreach (SceneData data in sceneData)
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
}
